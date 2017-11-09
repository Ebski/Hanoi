using HanoiTower.Services;
using System;
using System.Collections.Generic;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Insert number of discs");
            string numberOfDiscs = Console.ReadLine();

            Hanoi hanoi = new Hanoi(Convert.ToInt32(numberOfDiscs));

            Console.WriteLine("\n\n Press any key to close program");
            Console.ReadKey();
        }
    }
}
