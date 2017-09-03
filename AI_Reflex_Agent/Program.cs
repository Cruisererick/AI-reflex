using System;

namespace AI_Reflex_Agent
{
    class Program
    {
        static void Main(string[] args)
        {
			Map map = Map.getInstance();
			Map.printMap();
			//Random_Agent random = new Random_Agent(0, 0, Map.getMatrix());
			//random.MakeRun(200);

			Reflex_Agent reflex = new Reflex_Agent(8, 11, Map.getMatrix());
			reflex.Execute();

			Console.WriteLine("Press enter to close...");
			Console.ReadLine();
		}
    }
}
