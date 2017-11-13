using HanoiTower.Services;
using System;


namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Validation v = new Validation();

            while (true)
            {
                Console.WriteLine("Choose a height for the towers. Value must be between 2 and 10");
                string height = Console.ReadLine();
                
                if (v.ValidateStartInput(height))
                {
                    Console.WriteLine("Press 1 to see a simulazion of how to solve it. Press 2 to try yourself");
                    string choice = Console.ReadLine();

                    if (v.ValidateChoice(choice))
                    {
                        if (choice == "1")
                        {
                            HanoiSimulator hanoi = new HanoiSimulator(Convert.ToInt32(height));
                        } else
                        {
                            HanoiPuzzle puzzle = new HanoiPuzzle(Convert.ToInt32(height));
                            puzzle.Play();
                        }
                    }
                }
                Console.WriteLine("\n\n Press Escape to close the program, press any other key to try again");
                var exit = Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
