using System;
using System.Collections.Generic;

namespace HanoiTower.Services
{
    public class HanoiSimulator
    {
        private Print print;
        // Y axis in the console window
        private int y = 5;
        // Max height of the towers
        private int maxHeight;
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
        public HanoiSimulator(int height)
        {
            // Sets max height variable
            this.maxHeight = height;
            print = new Print(maxHeight);
            
            // Add circles to the first tower.
            for (int i = maxHeight; i > 0; i--)
            {
                Tower1.Push(i);
            }
                
            // Print towers before algorithm starts
            y = print.PrintTowers(Tower1, Tower2, Tower3, y);

            // Run the algorithm.
            SolveHanoi(maxHeight, Tower1, Tower2, Tower3);
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
                y = print.PrintTowers(Tower1, Tower2, Tower3, y);
                return;
            }

            // Call the algorithm again. This time the otherTower is used as the toTower parameter.
            SolveHanoi(height - 1, fromTower, otherTower, toTower);

            // Move ring from the fromTower to toTower
            toTower.Push(fromTower.Pop());
            //Print how the towers look now.
            y = print.PrintTowers(Tower1, Tower2, Tower3, y);

            // Call the algorithm again. This time The otherTower is used as the from tower variable. and the fromTower is the otherTower variable.
            SolveHanoi(height - 1, otherTower, toTower, fromTower);
        }
    }
}
