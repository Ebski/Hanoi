using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Services
{
    public class HanoiPuzzle
    {
        Print print;
        private int y;
        private int maxHeight;
        private Stack<int> Tower1 { get; set; } = new Stack<int>();
        private Stack<int> Tower2 { get; set; } = new Stack<int>();
        private Stack<int> Tower3 { get; set; } = new Stack<int>();
        public HanoiPuzzle(int height)
        {
            y = 5;
            maxHeight = height;
            print = new Print(maxHeight);
            for (int i = maxHeight; i > 0; i--)
            {
                Tower1.Push(i);
            }
        }

        public void Play()
        {
            while(Tower3.Count != maxHeight && Tower2.Count != maxHeight)
            {
                y = print.PrintTowers(Tower1, Tower2, Tower3, y);
                Console.WriteLine("MOVE");
                string move1 = Console.ReadLine();
                Console.WriteLine("MOVE");
                string move2 = Console.ReadLine();
                Move(move1, move2);
            }
            y = print.PrintTowers(Tower1, Tower2, Tower3, y);
        }

        private void Move(string x, string y)
        {
            Stack<int> from = GetTowerFromInput(x);
            Stack<int> to = GetTowerFromInput(y);

            to.Push(from.Pop());
        }

        private Stack<int> GetTowerFromInput(string x)
        {
            Stack<int> tower;

            if (x == "1")
            {
                tower = Tower1;
            }
            else if (x == "2")
            {
                tower = Tower2;
            }
            else
            {
                tower = Tower3;
            }
            return tower;
        }

    }
}
