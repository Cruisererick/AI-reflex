using System;

namespace AI_Reflex_Agent
{
    class Program
    {
        static void Main(string[] args)
        {
			Map mapRandom = new Map();
			Map mapReflex = Map.Clone(mapRandom);
			Random_Agent random = new Random_Agent(3, 6, mapRandom);
			random.MakeRun(200);
			Console.WriteLine("Press enter to run reflex agent.");
			Console.ReadLine();
			Console.Clear();
			mapReflex.printMap();
			Reflex_Agent reflex = new Reflex_Agent(3, 6, mapReflex);
			reflex.Execute();

			Console.WriteLine("Press enter to close...");
			Console.ReadLine();
		}
    }
}
