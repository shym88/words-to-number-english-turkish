

namespace Calculator.Interface
{
    public interface IWordsToNumber
    {
        public long ConvertWords(string number);
        public long ConvertToNumbers(string[] words);

        public string[] SubArray(string[] array, int start, int end);
           
        
    }
}
