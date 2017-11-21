using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Services
{
    public class HanoiPuzzle
    {
        Print print;
        Validation validate;
        private string errorMessage = "";
        bool error;
        private int y;
        private int maxHeight;
        private Stack<int> Tower1 { get; set; } = new Stack<int>();
        private Stack<int> Tower2 { get; set; } = new Stack<int>();
        private Stack<int> Tower3 { get; set; } = new Stack<int>();
        public HanoiPuzzle(int height)
        {
            validate = new Validation();
            error = false;
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
                Console.WriteLine("Move from");
                string move1 = Console.ReadLine();
                Console.WriteLine("Move to");
                string move2 = Console.ReadLine();
                if (ValidInput(move1, move2))
                {
                    Move(move1, move2);
                    if (error)
                    {
                        Console.WriteLine(errorMessage);
                        y = y + maxHeight;
                        error = false;
                    }
                } else
                {
                    Console.WriteLine(errorMessage);
                    y = y + maxHeight;
                }
            }
            y = print.PrintTowers(Tower1, Tower2, Tower3, y);
        }

        private void Move(string x, string y)
        {
            Stack<int> from = GetTowerFromInput(x);
            Stack<int> to = GetTowerFromInput(y);

            if (from.Count != 0)
            {
                if (to.Count == 0 ||from.Peek() < to.Peek())
                {
                    to.Push(from.Pop());
                }
                else
                {
                    errorMessage = "Invalid move";
                    error = true;
                }
            } else
            {
                errorMessage = "Invalid move";
                error = true;
            }
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

        public bool ValidInput(string moveFrom, string moveTo)
        {
            if (moveFrom == moveTo)
            {
                errorMessage = "Can't move disc to the same tower.";
                return false;
            }
            if (!validate.ValidateMoveInput(moveFrom) || !validate.ValidateMoveInput(moveTo))
            {
                errorMessage = "You must choose 1, 2 or 3 for both moves";
                return false;
            }
            return true;
        }

    }
}
