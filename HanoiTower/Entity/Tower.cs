using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Entity
{
    public class Tower
    {
        private int height;
        private int y = 3;
        int[] rings = new int[0];

        /// <summary>
        /// Default Constructor. Height is set to 3
        /// </summary>
        public Tower()
        {
            height = 3;
        }

        /// <summary>
        /// Constructor where height is set
        /// </summary>
        /// <param name="height"></param>
        public Tower(int height)
        {
            this.height = height;
        }

        // other functions
        public void AddRing(int size)
        {
            Array.Resize(ref rings, rings.Length + 1);
            rings[rings.Length - 1] = size;
        }

        public void DrawPeg(int x, int numberOfRings = 0)
        {
            for (int i = height; i >= 1; i--)
            {
                string halfRing = new string(' ', i);
                if (numberOfRings > 0)
                {
                    if (i <= numberOfRings)
                        halfRing = new string('-', numberOfRings - i + 1);

                }

                Console.SetCursorPosition(x - halfRing.Length * 2 + i + (halfRing.Contains("-") ? (-i + halfRing.Length) : 0), y);
                Console.WriteLine(halfRing + "|" + halfRing);
                y++;
            }

            if (x < height-1)
            {
                x = height-1;
            }


            Console.SetCursorPosition(x - height - 1, y); // print the base
            Console.WriteLine();
            for (int i = 0; i < height - 1; i++)
            {
                Console.Write('-');
            }
        }
    }
}
