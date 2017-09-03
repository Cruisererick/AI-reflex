using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AI_Reflex_Agent
{
    class Reflex_Agent 
    {
		private int CurrentXPosition;
		private int CurrentYPosition;
		private int PlanXPosition;
		private int PlanYPosition;
		private Map map;
		private int Points;
		private static List<List<int>> Paths = new List<List<int>>();
		int CrossOneX = 3;
		int CrossOneY = 3;

		int CrossTwoX = 8;
		int CrossTwoY = 3;

		int CrossTreeX = 3;
		int CrossTreeY = 8;

		int CrossFourX = 8;
		int CrossFourY = 8;

		List<int> pool = new List<int>();


		public Reflex_Agent(int x, int y, Map map)
		{
			CurrentXPosition = x;
			CurrentYPosition = y;
			PlanXPosition = x;
			PlanYPosition = y;
			this.map = map;
			Points = 0;
			PlanRun();
		}


		public void Execute()
		{
			for (int i = 0; i < pool.Count(); i++)
			{
				if (pool[i] == 1)
				{
					MoveRight();
					Clean();
					map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
					Console.Clear();
					map.printMap();
					Console.WriteLine("Current Reflex Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
					Console.WriteLine("Current Reflex Rumba Points:" + Points);
				}
				else if (pool[i] == 2)
				{
					MoveLeft();
					Clean();
					map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
					Console.Clear();
					map.printMap();
					Console.WriteLine("Current Reflex Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
					Console.WriteLine("Current Reflex Rumba Points:" + Points);
				}
				else if (pool[i] == 3)
				{
					MoveDown();
					Clean();
					map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
					Console.Clear();
					map.printMap();
					Console.WriteLine("Current Reflex Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
					Console.WriteLine("Current Reflex Rumba Points:" + Points);
				}
				else if (pool[i] == 4)
				{
					MoveUp();
					Clean();
					map.setMatrixPos(CurrentXPosition, CurrentYPosition, "R");
					Console.Clear();
					map.printMap();
					Console.WriteLine("Current Reflex Rumba Position:" + " X:" + CurrentXPosition + " Y:" + CurrentYPosition);
					Console.WriteLine("Current Reflex Rumba Points:" + Points);
				}


				int milliseconds = 50;
				Thread.Sleep(milliseconds);
			}
		}

		private void PlanRun()
		{
			
			List<int> distances = new List<int>();

			distances.Add(Math.Abs(PlanXPosition - CrossOneX) + Math.Abs(PlanYPosition - CrossOneY));
			distances.Add(Math.Abs(PlanXPosition - CrossTwoX) + Math.Abs(PlanYPosition - CrossTwoY));
			distances.Add(Math.Abs(PlanXPosition - CrossTreeX) + Math.Abs(PlanYPosition - CrossTreeY));
			distances.Add(Math.Abs(PlanXPosition - CrossFourX) + Math.Abs(PlanYPosition - CrossFourY));

			
			int minDistance;
			int minIndex;
			int runs = 0;
			minDistance = distances.Min();
			minIndex = distances.IndexOf(minDistance);
			if (minIndex == 0)
			{
				distances.Clear();
				distances.Add(0);
				distances.Add(1);
				distances.Add(2);
				distances.Add(3);

			}
			else if (minIndex == 1)
			{
				distances.Clear();
				distances.Add(1);
				distances.Add(0);
				distances.Add(2);
				distances.Add(3);
			}
			else if (minIndex == 2)
			{
				distances.Clear();
				distances.Add(2);
				distances.Add(3);
				distances.Add(0);
				distances.Add(1);
			}
			else if (minIndex == 3)
			{
				distances.Clear();
				distances.Add(3);
				distances.Add(2);
				distances.Add(0);
				distances.Add(1);
			}
			for (int i = 0; i < distances.Count; i++)
			{
				if (distances[i] == 0)
				{
					goToCrossOne(PlanXPosition, PlanYPosition, pool);
					runs = runs + 1;
				}
				else if (distances[i] == 1)
				{
					goToCrossTwo(PlanXPosition, PlanYPosition, pool);
					runs = runs + 1;
				}
				else if (distances[i] == 2)
				{
					goToCrossTree(PlanXPosition, PlanYPosition, pool);
					runs = runs + 1;
				}
				else if (distances[i] == 3)
				{
					goToCrossFour(PlanXPosition, PlanYPosition, pool);
					runs = runs + 1;
				}
			}
		}

		public void goToCrossOne(int x, int y, List<int> pool)
		{
			while (x != CrossOneX || y != CrossOneY)
			{

				while (y != CrossOneY)
				{
					if (y > CrossOneY)
					{
						if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						{
							moveLeft(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (y < CrossOneY)
					{
						if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
						{
							moveRight(ref x, ref y, pool);
						}
						else
							break;
					}
				}

				while (x != CrossOneX)
				{
					if (x > CrossOneX)
					{
						if (map.getStatusOnPos(x - 1, y).CompareTo(" ") != 0)
						{
							moveUp(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (x < CrossOneX)
					{
						if (map.getStatusOnPos(x + 1, y).CompareTo(" ") != 0)
						{
							moveDown(ref x, ref y, pool);
						}
						else
							break;
					}
				}
			}
			moveUp(ref x, ref y, pool);
			moveUp(ref x, ref y, pool);
			moveUp(ref x, ref y, pool);

			while ((x != CrossOneX) || (y != CrossOneY))
			{
				while (true)
				{
					if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						moveLeft(ref x, ref y, pool);
					else
						break;
				}
				moveDown(ref x, ref y, pool);

				while (true)
				{
					if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0 && y != CrossOneY)
					{
						moveRight(ref x, ref y, pool);
					}
					else
						break;
				}
				if ((x != CrossOneX) || (y != CrossOneY))
					moveDown(ref x, ref y, pool);
				else
					break;
			}

			PlanXPosition = x;
			PlanYPosition = y;

		}

		public void goToCrossTwo(int x, int y, List<int> pool)
		{
			while (x != CrossTwoX || y != CrossTwoY)
			{

				while (y != CrossTwoY)
				{
					if (y > CrossTwoY)
					{
						if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						{
							moveLeft(ref x, ref y, pool);
						}
						else if (x == CrossTwoX)
						{
							while (map.getStatusOnPos(x, y - 1).CompareTo(" ") == 0)
							{
								moveUp(ref x, ref y, pool);
							}
						}
						else
							break;
					}
					else if (y < CrossTwoY)
					{
						if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
						{
							moveRight(ref x, ref y, pool);
						}
						else
							break;
					}
				}

				while (x != CrossTwoX)
				{
					if (x > CrossTwoX)
					{
						if (map.getStatusOnPos(x - 1, y).CompareTo(" ") != 0)
						{
							moveUp(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (x < CrossTwoX)
					{
						if (map.getStatusOnPos(x + 1, y).CompareTo(" ") != 0)
						{
							moveDown(ref x, ref y, pool);
						}
						else
							break;
					}
				}
			}
			moveDown(ref x, ref y, pool);
			moveDown(ref x, ref y, pool);
			moveDown(ref x, ref y, pool);

			while ((x != CrossTwoX) || (y != CrossTwoY))
			{
				while (true)
				{
					if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						moveLeft(ref x, ref y, pool);
					else
						break;
				}
				moveUp(ref x, ref y, pool);

				while (true)
				{
					if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0 && y != CrossTwoY)
					{
						moveRight(ref x, ref y, pool);
					}
					else
						break;
				}

				if ((x != CrossTwoX) || (y != CrossTwoY))
					moveUp(ref x, ref y, pool);
				else
					break;
			}

			PlanXPosition = x;
			PlanYPosition = y;

		}

		public void goToCrossTree(int x, int y, List<int> pool)
		{
			while (x != CrossTreeX || y != CrossTreeY)
			{

				while (y != CrossTreeY)
				{
					if (y > CrossTreeY)
					{
						if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						{
							moveLeft(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (y < CrossTreeY)
					{
						if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
						{
							moveRight(ref x, ref y, pool);
						}
						else
							break;
					}
				}

				while (x != CrossTreeX)
				{
					if (x > CrossTreeX)
					{
						if (map.getStatusOnPos(x - 1, y).CompareTo(" ") != 0)
						{
							moveUp(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (x < CrossTreeX)
					{
						if (map.getStatusOnPos(x + 1, y).CompareTo(" ") != 0)
						{
							moveDown(ref x, ref y, pool);
						}
						else
							break;
					}
				}
			}
			moveUp(ref x, ref y, pool);
			moveUp(ref x, ref y, pool);
			moveUp(ref x, ref y, pool);

			while ((x != CrossTreeX) || (y != CrossTreeY))
			{
				while (true)
				{
					if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
					{
						moveRight(ref x, ref y, pool);
					}
					else
						break;
				}
				moveDown(ref x, ref y, pool);

				while (true)
				{
					if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0 && y != CrossTreeY)
					{
						moveLeft(ref x, ref y, pool);
					}
					else
						break;
				}

				if ((x != CrossTreeX) || (y != CrossTreeY))
					moveDown(ref x, ref y, pool);
				else
					break;
			}

			PlanXPosition = x;
			PlanYPosition = y;

		}

		public void goToCrossFour(int x, int y, List<int> pool)
		{
			while (x != CrossFourX || y != CrossFourY)
			{

				while (y != CrossFourY)
				{
					if (y > CrossFourY)
					{
						if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0)
						{
							moveLeft(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (y < CrossFourY)
					{
						if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
						{
							moveRight(ref x, ref y, pool);
						}
						else if (x == CrossFourX)
						{
							while (map.getStatusOnPos(x, y + 1).CompareTo(" ") == 0)
							{
								moveUp(ref x, ref y, pool);
							}
						}
						else
							break;
					}
				}

				while (x != CrossFourX)
				{
					if (x > CrossFourX)
					{
						if (map.getStatusOnPos(x - 1, y).CompareTo(" ") != 0)
						{
							moveUp(ref x, ref y, pool);
						}
						else
							break;
					}
					else if (x < CrossFourX)
					{
						if (map.getStatusOnPos(x + 1, y).CompareTo(" ") != 0)
						{
							moveDown(ref x, ref y, pool);
						}
						else
							break;
					}
				}
			}
			moveDown(ref x, ref y, pool);
			moveDown(ref x, ref y, pool);
			moveDown(ref x, ref y, pool);

			while ((x != CrossFourX) || (y != CrossFourY))
			{
				while (true)
				{
					if (map.getStatusOnPos(x, y + 1).CompareTo(" ") != 0)
						moveRight(ref x, ref y, pool);
					else
						break;
				}
				moveUp(ref x, ref y, pool);

				while (true)
				{
					if (map.getStatusOnPos(x, y - 1).CompareTo(" ") != 0 && y != CrossTreeY)
					{
						moveLeft(ref x, ref y, pool);
					}
					else
						break;
				}

				if ((x != CrossFourX) || (y != CrossFourY))
					moveUp(ref x, ref y, pool);
				else
					break;
			}

			PlanXPosition = x;
			PlanYPosition = y;

		}

		public void moveRight(ref int x, ref int y, List<int> pool)
		{
			y = y + 1;
			pool.Add(1);
			
		}

		public void moveUp(ref int x, ref int y, List<int> pool)
		{
			x = x - 1;
			pool.Add(4);
			
		}

		public void moveLeft(ref int x, ref int y, List<int> pool)
		{
			y = y - 1;
			pool.Add(2);
			
		}

		public void moveDown(ref int x, ref int y, List<int> pool)
		{
			x = x + 1;
			pool.Add(3);
			
		}

		public void MoveRight()
		{
			CurrentYPosition = CurrentYPosition + 1;
		}

		public void MoveLeft()
		{
			CurrentYPosition = CurrentYPosition - 1;
		}

		public void MoveUp()
		{
			CurrentXPosition = CurrentXPosition - 1;
		}

		public void MoveDown()
		{
			CurrentXPosition = CurrentXPosition + 1;
		}

		public void Clean()
		{
			if (map.getStatusOnPos(CurrentXPosition, CurrentYPosition).CompareTo("T") == 0)
			{
				map.setMatrixPos(CurrentXPosition, CurrentYPosition, "C");
				Points = Points + 100;

			}
		}
	}
}
