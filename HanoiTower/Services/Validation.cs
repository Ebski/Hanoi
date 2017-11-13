using System;
using System.Collections.Generic;
using System.Text;

namespace HanoiTower.Services
{
    public class Validation
    {
        public bool ValidateStartInput(string s)
        {
            return s == "2" || s == "3" || s == "4" || s == "5" || s == "6" || s == "7" || s == "8" || s == "9" || s == "10";
        }

        public bool ValidateChoice(string s)
        {
            return s == "1" || s == "2";
        }
    }
}
