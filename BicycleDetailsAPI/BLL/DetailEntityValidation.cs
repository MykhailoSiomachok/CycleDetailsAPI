using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LowerLayer;

namespace BLL
{
    class DetailEntityValidation
    {
        public static bool IsEntityValid(BicycleDetail detail)
        {
            if(IsValueValid(detail.Type)&& IsValueValid(detail.Producer)&& IsValueValid(detail.Brand) && IsColorValid(detail.Color))
            {
                return true;
            }
            return false;
        }
        private static bool IsValueValid(string value)
        {
            if(value.Any(char.IsDigit) || value.Length < 3)
            {
                return false;
            }
            return true;
        }
        private static bool IsColorValid(string color)
        {
            string[] colors = new string[] { "red", "blue", "yellow", "pink", "green" };
            if(colors.Contains(color))
            {
                return true;
            }
            return false;
        }
    }

}
