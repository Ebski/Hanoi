using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Services
{
    public class Print
    {
        public int MaxHeight { get; set; }
        private Dictionary<int, string> printDictonary = new Dictionary<int, string>();

        public Print(int height)
        {
            MaxHeight = height;
            FillUpPrintMap();
        }

        /// <summary>
        /// Print the Towers of Hanoi
        /// </summary>
        /// <param name="tower1"></param>
        /// <param name="tower2"></param>
        /// <param name="tower3"></param>
        public int PrintTowers(Stack<int> tower1, Stack<int> tower2, Stack<int> tower3, int y)
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
            return  y + MaxHeight + 2;
        }

        /// <summary>
        /// Print one Tower of Hanoi
        /// </summary>
        /// <param name="tower"></param>
        /// <param name="towerName"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        public void PrintTower(Stack<int> tower, string towerName, int xPos, int yPos)
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
