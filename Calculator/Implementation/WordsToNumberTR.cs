using Calculator.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Calculator.Implementation
{
    public class WordsToNumberTR : IWordsToNumber
    {

        string[] ones = { "bir", "iki", "üç", "dört", "beş", "altı", "yedi", "sekiz", "dokuz" };
        string[] tens = { "on", "yirmi", "otuz", "kırk", "elli", "altmış", "yetmiş", "seksen", "doksan" };

        private string[] paramsForSplit = new string[] { "", "bin", "milyon", "milyar" };
        private  Dictionary<string, long> powersofTen = new Dictionary<string, long>() {
                                                {"milyar", 1000000000},
                                                {"milyon", 1000000},
                                                {"bin", 1000},
                                                {"yüz", 100}
                                            };
     
        public  Dictionary<string, long> factor = new Dictionary<string, long>() {
            { "bir", 1 },
            { "iki", 2 },
            { "üç", 3 },
            { "dört", 4 },
            { "beş", 5 },
            { "altı", 6 },
            { "yedi", 7 },
            { "sekiz", 8 },
            { "dokuz", 9 },
            { "on", 10 },
            { "yirmi", 20 },
            { "otuz", 30 },
            { "kırk", 40 },
            { "elli", 50 },
            { "altmış", 60 },
            { "yetmiş", 70 },
            { "seksen", 80 },
            { "doksan", 90 },
            {"milyar", 1000000000},
            {"milyon", 1000000},
            {"bin", 1000},
            {"yüz", 100}
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
                if (words.Length == 1 && words.Contains("sıfır"))
                    return 0;
                else if(words.Length>0 && words.Contains("sıfır"))
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
                                else if (index==0 && words.Contains("bin") )
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
                    //// Control MODIFIER must come after ONES OR TENS except (yüz,bin) !!!!!!!!!!!
                    /// Example: bir trilyon yüz yetmiş beş
                    if (words[i] != "yüz" && words[i] != "bin")
                        if (words.Length == 1)
                            throw new ApplicationException("err-03");
                        else if (!ones.Contains(words[i - 1]) && !tens.Contains(words[i - 1]))
                            throw new ApplicationException("err-03");
                    /////////
                   
                   if(i==0)
                        result = factor[words[i]] * 1;
                   else
                        result = factor[words[i]] * result;


                }

                else
                {
                    if (i < (words.Count() - 1))
                    {
                        ////    Control TENS cannot come after TEENS
                        ///     Example: yüz bir on
                        if(i>0)
                            if (tens.Contains(words[i]) && ones.Contains(words[i - 1]))
                                throw new ApplicationException("err-03");
                        /////////

                        

                        ////    Control TEENS or TENS cannot come after ONES
                        ///     Example: yüz bir elli
                        if (ones.Contains(words[i]) && (tens.Contains(words[i + 1])))
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
