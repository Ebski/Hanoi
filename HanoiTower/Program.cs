using HanoiTower.Services;
using System;


namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Choose a height for the towers");
            string height = Console.ReadLine();

            Hanoi hanoi = new Hanoi(Convert.ToInt32(height));

            Console.WriteLine("\n\n Press any key to close program");
            Console.ReadKey();
        }
    }
}
