using System;
using System.Collections.Generic;

namespace HanoiTower.Services
{
    public class Hanoi
    {
        // Y axis in the console window
        private int y = 5;
        // Max height of the towers
        private int MaxHeight { get; set; } = 0;
        // The towers
        private Stack<int> Tower1 { get; set; } = new Stack<int>();
        private Stack<int> Tower2 { get; set; } = new Stack<int>();
        private Stack<int> Tower3 { get; set; } = new Stack<int>();
        // Dictonary used for printing
        private Dictionary<int, string> printDictonary = new Dictionary<int, string>();

        /// <summary>
        /// Constructer
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        public Hanoi(int MaxHeight)
        {
            // Sets max height variable
            this.MaxHeight = MaxHeight;
            // Fill up the Dictonary
            FillUpPrintMap();
            
            // Add circles to the first tower.
            for (int i = MaxHeight; i > 0; i--)
            {
                Tower1.Push(i);
            }

            // Print towers before algorithm starts
            PrintTowers(Tower1, Tower2, Tower3);

            // Run the algorithm.
            SolveHanoi(MaxHeight, Tower1, Tower2, Tower3);
        }

        /// <summary>
        /// Recursive Alogorithm to solve Tower of Hanoi
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        /// <param name="fromTower"></param>
        /// <param name="toTower"></param>
        /// <param name="otherTower"></param>
        public void SolveHanoi(int height, Stack<int> fromTower, Stack<int> toTower, Stack<int> otherTower)
        {
            // Devide the problem into smaller bits. When the height of the towers are 1, we can't devide it more.
            if (height == 1)
            {
                // Move ring from fromTower to toTower.
                toTower.Push(fromTower.Pop());
                // Print how the towers look now.
                PrintTowers(Tower1, Tower2, Tower3);
                return;
            }

            // Call the algorithm again. This time the otherTower is used as the toTower parameter.
            SolveHanoi(height - 1, fromTower, otherTower, toTower);

            // Move ring from the fromTower to toTower
            toTower.Push(fromTower.Pop());
            //Print how the towers look now.
            PrintTowers(Tower1, Tower2, Tower3);

            // Call the algorithm again. This time The otherTower is used as the from tower variable. and the fromTower is the otherTower variable.
            SolveHanoi(height - 1, otherTower, toTower, fromTower);
        }

        /// <summary>
        /// Print the Towers of Hanoi
        /// </summary>
        /// <param name="tower1"></param>
        /// <param name="tower2"></param>
        /// <param name="tower3"></param>
        private void PrintTowers(Stack<int> tower1, Stack<int> tower2, Stack<int> tower3)
        {
            // Wait 1 second. Done so movements can be seen.
            System.Threading.Thread.Sleep(1000);
            // Print tower 1.
            PrintTower(tower1, "tower 1", 20, y);
            // Print tower 2.
            PrintTower(tower2, "tower 2", 40, y);
            // Print tower 3.
            PrintTower(tower3, "tower 3", 60, y);
            // Adjust y axis in the console window, to not overwrite previoisly printed towers.
            y = y + MaxHeight + 2;
        }

        /// <summary>
        /// Print one Tower of Hanoi
        /// </summary>
        /// <param name="tower"></param>
        /// <param name="towerName"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public void PrintTower(Stack<int> tower, string towerName,int xPos, int yPos)
        {
            // Set where in the Console Window the printing should happend.
            Console.SetCursorPosition(xPos - (MaxHeight / 2), yPos);
            Console.WriteLine(towerName);
            // Set initial brick index
            int brickIndex = 0;

            for (int i = MaxHeight; i >= 1; i--)
            {
                Console.SetCursorPosition(xPos, yPos + i);
                // Print base tower line.
                Console.WriteLine("|");
                // If the tower contains i.
                if (tower.Contains(i))
                {
                    // Adjust height based on number of bricks
                    int bPos = MaxHeight - brickIndex;
                    // Adjust the printing line to write infront of the base tower line.
                    Console.SetCursorPosition(xPos - i, yPos + bPos);
                    //Console.SetCursorPosition(xPos - i, yPos + i);
                    // Print out the rings infront of the base tower line.
                    Console.WriteLine(printDictonary[i]);
                    // Adjust the printing line to write after the base tower line.
                    Console.SetCursorPosition(xPos + 1, yPos + bPos);
                    // Print out the rings after the base tower line.
                    Console.WriteLine(printDictonary[i]);
                    // Increment brick index
                    brickIndex++;
                }
            }
            // Increment y position to print on the next line.
            yPos++;
        }

        /// <summary>
        /// Create a printing map.
        /// </summary>
        /// <param name="numberOfDiscs"></param>
        private void FillUpPrintMap()
        {
            for (int i = 1; i <= MaxHeight; i++)
            {
                string printString = "";
                for (int j = 0; j < i; j++)
                {
                    printString += "-";
                }
                printDictonary.Add(i, printString);
            }
        }
        
    }
}
