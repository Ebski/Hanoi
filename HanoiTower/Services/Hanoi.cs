using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Services
{
    public class Hanoi
    {
        private int numberOfDiscs { get; set; } = 0;
        private Stack<int> Tower1 { get; set; } = new Stack<int>();
        private Stack<int> Tower2 { get; set; } = new Stack<int>();
        private Stack<int> Tower3 { get; set; } = new Stack<int>();
        private Dictionary<int, string> printDictonary = new Dictionary<int, string>();

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        public Hanoi(int numberOfDiscs)
        {
            FillUpPrintMap(numberOfDiscs);
            this.numberOfDiscs = numberOfDiscs;
            for (int i = numberOfDiscs; i > 0; i--)
            {
                Tower1.Push(i);
            }
            SolveHanoi(numberOfDiscs, Tower1, Tower2, Tower3);
        }

        public void SolveHanoi(int numberOfDiscs, Stack<int> fromTower, Stack<int> toTower, Stack<int> otherTower)
        {
            if (numberOfDiscs == 1)
            {
                toTower.Push(fromTower.Pop());
                PrintTower(fromTower, otherTower, toTower);
                return;
            }

            SolveHanoi(numberOfDiscs - 1, fromTower, otherTower, toTower);

            toTower.Push(fromTower.Pop());
            PrintTower(fromTower, otherTower, toTower);

            SolveHanoi(numberOfDiscs - 1, otherTower, toTower, fromTower);
        }

        private void PrintTower(Stack<int> tower1, Stack<int> tower2, Stack<int> tower3)
        {
            System.Threading.Thread.Sleep(1000);
            int numberOfEmptySpaces = 0;
            string emptySpace = "";

            Console.WriteLine("tower1");
            foreach (int i in tower1)
            {
                numberOfEmptySpaces = numberOfDiscs - i;

                for (int j = 0; j < numberOfEmptySpaces; j++)
                {
                    emptySpace += " ";
                }
                
                Console.WriteLine(emptySpace + printDictonary[i] + emptySpace);
                emptySpace = "";
            }
            Console.WriteLine();

            Console.WriteLine("tower2");
            foreach (int i in tower2)
            {
                numberOfEmptySpaces = numberOfDiscs - i;

                for (int j = 0; j < numberOfEmptySpaces; j++)
                {
                    emptySpace += " ";
                }

                Console.WriteLine(emptySpace + printDictonary[i] + emptySpace);
                emptySpace = "";
            }
            Console.WriteLine();

            Console.WriteLine("tower 3");
            foreach (int i in tower3)
            {
                numberOfEmptySpaces = numberOfDiscs - i;

                for (int j = 0; j < numberOfEmptySpaces; j++)
                {
                    emptySpace += " ";
                }

                Console.WriteLine(emptySpace + printDictonary[i] + emptySpace);
                emptySpace = "";
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
