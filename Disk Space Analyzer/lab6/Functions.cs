using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public static class Functions
    {
        public static string SizeToString(long size)
        {
            string s;
            NumberFormatInfo setPrecision = new NumberFormatInfo();
            setPrecision.NumberDecimalDigits = 1;
            if (size < 1024)
                s = $"{((float)size).ToString("N", setPrecision)} Bytes";
            else if (size < 1024 * 1024)
                s = $"{((float)size / 1024).ToString("N", setPrecision)} KB";
            else if (size < 1024 * 1024 * 1024)
                s = $"{((float)size / 1024 / 1024).ToString("N", setPrecision)} MB";
            else
                s = $"{((float)size / 1024 / 1024 / 1024).ToString("N", setPrecision)} GB";
            return s;
        }
        public static string ConvertToScientificNotation(long number)
        {
            if (number < 1000)
            {
                return number.ToString();
            }

            long absNumber = Math.Abs(number);
            int exponent = (int)Math.Floor(Math.Log10(absNumber));

            int coefficient = (int)(absNumber / Math.Pow(10, exponent));


            return $"{coefficient}*10^{Math.Abs(exponent)}";
        }
    }
}
