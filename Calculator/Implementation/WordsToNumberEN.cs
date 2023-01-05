using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Calculator.Implementation
{
    public class WordsToNumberEN : IWordsToNumber
    {

        private  string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private  string[] teens = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private  string[] tens = { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private string[] paramsForSplit = new string[] { "", "thousand", "million", "billion" };
        private  Dictionary<string, long> powersofTen = new Dictionary<string, long>() {
                                                {"billion", 1000000000},
                                                {"million", 1000000},
                                                {"thousand", 1000},
                                                {"hundred", 100}
                                            };

        private  Dictionary<string, long> factor = new Dictionary<string, long>() {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
            { "eleven", 11 },
            { "twelve", 12 },
            { "thirteen", 13 },
            { "fourteen", 14 },
            { "fifteen", 15 },
            { "sixteen", 16 },
            { "seventeen", 17 },
            { "eighteen", 18 },
            { "nineteen", 19 },
            { "ten", 10 },
            { "twenty", 20 },
            { "thirty", 30 },
            { "forty", 40 },
            { "fifty", 50 },
            { "sixty", 60 },
            { "seventy", 70 },
            { "eighty", 80 },
            { "ninety", 90 },
            {"billion", 1000000000},
            {"million", 1000000},
            {"thousand", 1000},
            {"hundred", 100}
        };

        public long ConvertWords(string number)
        {

            string[] words = number.ToLower().Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

            List<string[]> parts = new List<string[]>();
            long result = 0;
            int k = 0;
            int lastIndex = 0;
            int index = 0;

            try
            {
                if (words.Length == 1 && words.Contains("zero"))
                    return 0;
                else if (words.Length > 0 && words.Contains("zero"))
                    throw new ApplicationException("err-02");

                bool validWord = words.All(x => factor.ContainsKey(x));
                if (!validWord)
                    throw new ApplicationException("err-02");

                var countRepeatedpartModifiers = words
                    .Where(w => paramsForSplit.Contains(w))
                    .Select(s => s)
                    .GroupBy(s => s)
                    .Where(d => d.Count() > 1)
                    .ToList().Count();

                if (countRepeatedpartModifiers > 0)
                    throw new ApplicationException("err-03");


                bool needToSplit;
                if (words.Length > 1)
                    needToSplit = words.Any(x => paramsForSplit.Contains(x));
                else
                    needToSplit = false;

                //if (words.Length > 1 && needToSplit)
                if (needToSplit)
                    {
                        
                        for (int i = paramsForSplit.Length - 1; i >= 0; i--)
                        {
                          
                            if (!string.IsNullOrEmpty(paramsForSplit[i]))
                            {

                                index = Array.IndexOf(words, paramsForSplit[i]);
                                if (index > 0)
                                {
                                    lastIndex = index;
                                    parts.Add(SubArray(words, k, (index - k)));
                                    k = index + 1;
                                }
                            }
                        }

                        parts.Add(SubArray(words, lastIndex + 1, words.Length));

                    }
                    else
                    {
                        parts.Add(words);
                    }

                    foreach (var item in parts)
                    {
                        result = result + ConvertToNumbers(item.ToArray());
                    }

                

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public long ConvertToNumbers(string[] words)
        {

            /// Control the MODIFIER order
            /// Example: one hundred two thousand
            var writtenModifierKeys = words
                .Where(w => powersofTen.Keys.Contains(w))
                .Select(s => powersofTen[s])
                .ToList();
            var writtenModifierKeysSorted = writtenModifierKeys.OrderBy(i => i).ToList();
            if (!writtenModifierKeys.SequenceEqual(writtenModifierKeysSorted))
                throw new ApplicationException("err-03");
            ////////



            /// Control repeated MODIFIER and TEENS
            /// Example: one hundred two hundred
            var countRepeatedModifier = writtenModifierKeys
                .GroupBy(s => s)
                .Where(d => d.Count() > 1)
                .ToList().Count();
            if (countRepeatedModifier > 0)
                throw new ApplicationException("err-03");
            /////////


            long result = 0;
            for (int i = 0; i < words.Count(); i++)
            {

                if (powersofTen.ContainsKey(words[i]))
                {

                    //// Control MODIFIER must come after ONES OR TEENS OR TENS !!!!!!!!!!!
                    if (words.Length == 1)
                        throw new ApplicationException("err-03");
                    if (!ones.Contains(words[i - 1]) && !teens.Contains(words[i - 1]) && !tens.Contains(words[i - 1]) && words[i - 1]!="hundred")
                        throw new ApplicationException("err-03");
                    if(words[i] =="hundred" && result>9)
                        throw new ApplicationException("err-03");
                    /////////

                    result = factor[words[i]] * result;


                }

                else
                {
                    if (i < (words.Count() - 1))
                    {
                        ////    Control TENS cannot come after TEENS
                        ///     Example: one hundred TWENTY ELEVEN
                        if (tens.Contains(words[i]) && teens.Contains(words[i + 1]))
                            throw new ApplicationException("err-03");
                        /////////

                        ////    Control TEENS or ONES cannot come after TENS
                        ///     Example: one hundred ELEVEN TWENTY
                        ///     Example: one hundred ELEVEN ONE 
                        if (teens.Contains(words[i]) && (tens.Contains(words[i + 1]) || ones.Contains(words[i + 1])))
                            throw new ApplicationException("err-03");
                        /////////

                        ////    Control TEENS or TENS cannot come after ONES
                        ///     Example: one hundred FOUR THIRTEEN
                        ///     Example: one hundred FOUR FIFTY
                        if (ones.Contains(words[i]) && (teens.Contains(words[i + 1]) || tens.Contains(words[i + 1])))
                            throw new ApplicationException("err-03");
                        /////////
                        
                        result += factor[words[i]];
                    }
                    else
                        result += factor[words[i]];



                }

            }
            return result;

        }

        public string[] SubArray(string[] array, int start, int end)
        {
            return array.Skip(start).Take(end + 1).ToArray();
        }
    }
}
