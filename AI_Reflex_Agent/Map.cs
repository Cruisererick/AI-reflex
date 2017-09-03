using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Reflex_Agent
{
    class Map
    {
		private static string[,] matrix = new string[12, 12];
		private static Map map = null;
		private Map()
		{
			for (int i = 0; i < 12; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					matrix[i, j] = " ";
				}
				
			}

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					matrix[i, j] = "C";
					matrix[i + 8, j] = "C";
					matrix[i, j + 8] = "C";
					matrix[i + 8, j + 8] = "C";
				}

			}
			for (int i = 0; i < 4; i++)
			{
				matrix[3, i + 4] = "C";
				matrix[i + 4, 3] = "C";
				matrix[i + 4, 8] = "C";

			}
			matrix[3, 3] = "C";
			matrix[3, 8] = "C";
			matrix[8, 3] = "C";
			matrix[7, 8] = "C";
			GenerateTrash();


		}

		public static string[,] getMatrix()
		{
			return matrix;
		}

		public static string getStatusOnPos(int x, int y)
		{
			if (x > 11 || x < 0 || y > 11 || y < 0)
				return " ";
			else
				return matrix[x, y];
		}

		public static void setMatrixPos(int x, int y, string status)
		{
			matrix[x, y] = status;
		}

		public static void printMap()
		{
			if (map == null)
			{
				Console.WriteLine("No instance of map have been created.");
			}
			else
			{

				for (int i = 0; i < 12; i++)
				{
					for (int j = 0; j < 12; j++)
					{
						Console.Write(matrix[i, j]);
					}
					Console.WriteLine();
				}
			}
		}

		private void GenerateTrash()
		{
			Random rnd = new Random();
			int quantity = rnd.Next(15, 20);
			int placed = 0;
			int XPos = rnd.Next(0, 11);
			int YPos = rnd.Next(0, 11);

			while (placed < quantity)
			{
				if (matrix[XPos, YPos].CompareTo("C") == 0)
				{
					matrix[XPos, YPos] = "T";
					placed = placed + 1;
				}
				else
				{
					XPos = rnd.Next(0, 11);
					YPos = rnd.Next(0, 11);
				}
			}
			

		}

		public static Map getInstance()
		{
			if (map == null)
			{
				map = new Map();
				
			}

			return map;
		}
	}
}
