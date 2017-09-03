using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AI_Reflex_Agent
{
    class Random_Agent
    {
		private int CurrentXPosition;
		private int CurrentYPosition;
		private string[,] matrix;
		private int Points;

		public Random_Agent(int x, int y, string[,] matrix)
		{
			CurrentXPosition = x;
			CurrentYPosition = y;
			this.matrix = matrix;
			Points = 0;
		}

		public void MakeRun(int movements)
		{
			Random rnd = new Random();
			for (int i = 0; i < movements; i++)
			{
				Clean();
				Map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
				Move(rnd);
				Console.Clear();
				Map.printMap();
				Console.WriteLine("Current Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
				Console.WriteLine("Current Rumba Points:" + Points);
				int milliseconds = 50;
				Thread.Sleep(milliseconds);
			}
		}

		public void Clean()
		{
			if (matrix[CurrentXPosition, CurrentYPosition].CompareTo("T") == 0)
			{
				Map.setMatrixPos(CurrentXPosition, CurrentYPosition, "C");
				Points = Points + 100;
				
			}
		}

		public void Move(Random rnd)
		{
			int moveTo = rnd.Next(1, 5);
			int newX = CurrentXPosition;
			int newY = CurrentYPosition;

			if (moveTo == 1)
			{
				newX = newX + 1;
				if (Map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
				{
					Points = Points - 1;
					newX = CurrentXPosition;
					newY = CurrentYPosition;
				}
				else
				{
					Points = Points - 1;
				}
			}
			else if (moveTo == 2)
			{
				newX = newX - 1;
				if (Map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
				{
					Points = Points - 1;
					newX = CurrentXPosition;
					newY = CurrentYPosition;
				}
				else
				{
					Points = Points - 1;
				}
			}
			else if (moveTo == 3)
			{
				newY = newY + 1;
				if (Map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
				{
					Points = Points - 1;
					newX = CurrentXPosition;
					newY = CurrentYPosition;
				}
				else
				{
					Points = Points - 1;
				}
			}
			else if (moveTo == 4)
			{
				newY = newY - 1;
				if (Map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
				{
					Points = Points - 1;
					newX = CurrentXPosition;
					newY = CurrentYPosition;
				}
				else
				{
					Points = Points - 1;
				}
			}


			CurrentXPosition = newX;
			CurrentYPosition = newY;

		}

	}
}
