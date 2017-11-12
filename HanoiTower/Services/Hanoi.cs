using System;
using System.Collections.Generic;

namespace HanoiTower.Services
{
    public class Hanoi
    {
        private int y = 5;
        private int MaxHeight { get; set; } = 0;
        private Stack<int> Tower1 { get; set; } = new Stack<int>();
        private Stack<int> Tower2 { get; set; } = new Stack<int>();
        private Stack<int> Tower3 { get; set; } = new Stack<int>();
        private Dictionary<int, string> printDictonary = new Dictionary<int, string>();

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        public Hanoi(int MaxHeight)
        {
            FillUpPrintMap(MaxHeight);
            this.MaxHeight = MaxHeight;
            for (int i = MaxHeight; i > 0; i--)
            {
                Tower1.Push(i);
            }
            PrintTowers(Tower1, Tower2, Tower3);
            SolveHanoi(MaxHeight, Tower1, Tower2, Tower3);
        }

        public void SolveHanoi(int numberOfDiscs, Stack<int> fromTower, Stack<int> toTower, Stack<int> otherTower)
        {
            if (numberOfDiscs == 1)
            {
                toTower.Push(fromTower.Pop());
                PrintTowers(fromTower, otherTower, toTower);
                return;
            }

            SolveHanoi(numberOfDiscs - 1, fromTower, otherTower, toTower);

            toTower.Push(fromTower.Pop());
            PrintTowers(fromTower, otherTower, toTower);

            SolveHanoi(numberOfDiscs - 1, otherTower, toTower, fromTower);
        }

        private void PrintTowers(Stack<int> tower1, Stack<int> tower2, Stack<int> tower3)
        {
            System.Threading.Thread.Sleep(1000);
            PrintTower(tower1, "tower 1", 20, y);
            PrintTower(tower2, "tower 2", 40, y);
            PrintTower(tower3, "tower 3", 60, y);
            y = y + MaxHeight + 2;
        }

        public void PrintTower(Stack<int> tower, string towerName,int xPos, int yPos)
        {
            int numberOfEmptySpaces = 0;
            string emptySpace = "";

            Console.SetCursorPosition(xPos, yPos);
            Console.WriteLine(towerName);
            foreach (int i in tower)
            {
                numberOfEmptySpaces = MaxHeight - i;

                for (int j = 0; j < numberOfEmptySpaces; j++)
                {
                    emptySpace += " ";
                }
                Console.SetCursorPosition(xPos, yPos + 1);
                Console.WriteLine(emptySpace + printDictonary[i] + emptySpace);
                emptySpace = "";
                yPos++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Create a printing map.
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        private void FillUpPrintMap(int numberOfDiscs)
        {
            for (int i = 1; i <= numberOfDiscs; i++)
            {
                string printString = "|";
                for (int j = 0; j < i; j++)
                {
                    printString = "-" + printString;
                    printString += "-";
                }
                printDictonary.Add(i, printString);
            }
        }
        
    }
}
