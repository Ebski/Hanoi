using HanoiTower.Entity;
using HanoiTower.Services;
using System;
using System.Collections.Generic;

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

            //Tower tower1 = new Tower(Convert.ToInt32(height));
            //Tower tower2 = new Tower(Convert.ToInt32(height));
            //Tower tower3 = new Tower(Convert.ToInt32(height));

            //tower1.DrawPeg(20, 1);
            //tower1.DrawPeg(20, 2);
            //tower1.DrawPeg(20, 4);

            //Console.ReadKey();
        }
    }
}
