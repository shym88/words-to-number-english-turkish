using Calculator.Interface;
using System;



namespace Calculator.Implementation
{
    class NumberToWordTR: INumberToWord
    {
        public string NumberToWords(long number)
        {
            if (number == 0) return "Sıfır";
            if (number < 0) return "Eksi " + NumberToWords(Math.Abs(number));
            long trillion = number / 1000000000000;
            //long billions = number / 1000000000;
            long billions = (number - trillion * 1000000000000) / 1000000000;
            long millions = (number - trillion * 1000000000000 - billions * 1000000000) / 1000000;
            long thousands = (number - trillion * 1000000000000 - billions * 1000000000 - millions * 1000000) / 1000;
            //long thousands = (number - billions * 1000000000 - millions * 1000000) / 1000;
            long remainder = number - trillion * 1000000000000 - billions * 1000000000 - millions * 1000000 - thousands * 1000;

            string res = "";
            if (trillion != 0)
                res += threeDigit(trillion) + " Trilyon";
            if (billions != 0)
                res += threeDigit(billions) + " Milyar";
            if (millions != 0)
            {
                if (res != "")
                    res += " ";
                res += threeDigit(millions) + " Milyon";
            }
            if (thousands != 0)
            {
                if (res != "")
                    res += " ";
                if(thousands==1)
                    res += "Bin";
                else
                    res += threeDigit(thousands) + " Bin";
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
                case 1: return "Bir";
                case 2: return "İki";
                case 3: return "Üç";
                case 4: return "Dört";
                case 5: return "Beş";
                case 6: return "Altı";
                case 7: return "Yedi";
                case 8: return "Sekiz";
                case 9: return "Dokuz";
                
            }
            return "";
        }


        private static string ten(long num)
        {
            switch (num)
            {
                case 1: return "On";
                case 2: return "Yirmi";
                case 3: return "Otuz";
                case 4: return "Kırk";
                case 5: return "Elli";
                case 6: return "Altmış";
                case 7: return "Yetmiş";
                case 8: return "Seksen";
                case 9: return "Doksan";
            }
            return "";
        }

        private static string twoDigit(long num)
        {
            if (num == 0)
                return "";
            else if (num < 10)
                return one(num);
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
            else if (hundreds > 1 && remainder == 0)
                return one(hundreds) + " Yüz ";
            else if (hundreds == 1 && remainder == 0)
                return "Yüz ";
            else if (hundreds != 0 && remainder != 0)
            {
                if (hundreds > 1)
                    return one(hundreds) + " Yüz " + twoDigit(remainder);
                else
                    return "Yüz " + twoDigit(remainder);
            }

            else return "";
        }
    }
}
