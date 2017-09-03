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
		private Map map;
		private int Points;

		public Random_Agent(int x, int y, Map map)
		{
			CurrentXPosition = x;
			CurrentYPosition = y;
			this.map = map;
			Points = 0;
		}

		public void MakeRun(int movements)
		{
			Random rnd = new Random();
			for (int i = 0; i < movements; i++)
			{
				Clean();
				map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
				Move(rnd);
				Console.Clear();
				map.printMap();
				Console.WriteLine("Current Random Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
				Console.WriteLine("Current Random Rumba Points:" + Points);
				int milliseconds = 50;
				Thread.Sleep(milliseconds);
			}
		}

		public void Clean()
		{
			if (map.getStatusOnPos(CurrentXPosition, CurrentYPosition).CompareTo("T")==0)
			{
				map.setMatrixPos(CurrentXPosition, CurrentYPosition, "C");
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
				if (map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
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
				if (map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
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
				if (map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
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
				if (map.getStatusOnPos(newX, newY).CompareTo(" ") == 0)
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
