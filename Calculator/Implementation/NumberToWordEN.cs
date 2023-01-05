using Calculator.Interface;
using System;

/// <summary>
/// https://github.com/Zelong-Yu/IntegerToEnglishWords 
/// </summary>
/// 
namespace Calculator.Implementation
{
    class NumberToWordEN: INumberToWord
    {
        public string NumberToWords(long number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "Negative " + NumberToWords(Math.Abs(number));
            long trillion = number / 1000000000000;
            //long billions = number / 1000000000;
            long billions = (number - trillion * 1000000000000) / 1000000000;
            long millions = (number - trillion * 1000000000000 - billions * 1000000000) / 1000000;
            long thousands = (number - trillion * 1000000000000 - billions * 1000000000 - millions * 1000000) / 1000;
            //long thousands = (number - billions * 1000000000 - millions * 1000000) / 1000;
            long remainder = number - trillion * 1000000000000 - billions * 1000000000 - millions * 1000000 - thousands * 1000;

            string res = "";
            if (trillion != 0)
                res += threeDigit(trillion) + " Trillion";
            if (billions != 0)
                res += threeDigit(billions) + " Billion";
            if (millions != 0)
            {
                if (res != "")
                    res += " ";
                res += threeDigit(millions) + " Million";
            }
            if (thousands != 0)
            {
                if (res != "")
                    res += " ";
                res += threeDigit(thousands) + " Thousand";
            }
            if (remainder != 0)
            {
                if (res != "")
                    res += " ";
                res += threeDigit(remainder);
            }
            return res;

        }

        private static string one(long num)
        {
            switch (num)
            {
                case 1: return "One";
                case 2: return "Two";
                case 3: return "Three";
                case 4: return "Four";
                case 5: return "Five";
                case 6: return "Six";
                case 7: return "Seven";
                case 8: return "Eight";
                case 9: return "Nine";
            }
            return "";
        }

        private static string teen(long num)
        {
            switch (num)
            {
                case 10: return "Ten";
                case 11: return "Eleven";
                case 12: return "Twelve";
                case 13: return "Thirteen";
                case 14: return "Fourteen";
                case 15: return "Fifteen";
                case 16: return "Sixteen";
                case 17: return "Seventeen";
                case 18: return "Eighteen";
                case 19: return "Nineteen";
            }
            return "";
        }

        private static string ten(long num)
        {
            switch (num)
            {
                case 2: return "Twenty";
                case 3: return "Thirty";
                case 4: return "Forty";
                case 5: return "Fifty";
                case 6: return "Sixty";
                case 7: return "Seventy";
                case 8: return "Eighty";
                case 9: return "Ninety";
            }
            return "";
        }

        private static string twoDigit(long num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return one(num);
            else if (num < 20)
                return teen(num);
            else
            {
                long tens = num / 10;
                long ones = num - tens * 10;
                if (ones == 0)
                    return ten(tens);
                else
                    return ten(tens) + " " + one(ones);
            }
        }

        private static string threeDigit(long num)
        {
            long hundreds = num / 100;
            long remainder = num - hundreds * 100;
            if (hundreds == 0 && remainder != 0)
                return twoDigit(remainder);
            else if (hundreds != 0 && remainder == 0)
                return one(hundreds) + " Hundred";
            else if (hundreds != 0 && remainder != 0)
                return one(hundreds) + " Hundred " + twoDigit(remainder);
            else return "";
        }
    }
}
