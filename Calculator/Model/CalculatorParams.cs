

namespace Calculator.Model
{
    public class CalculatorParams
    {
        public CalculatorParams(long p1, long p2)
        {

            parameter_1 = p1;
            parameter_2 = p2;
        }
       public long parameter_1 { get; set; }
       public long parameter_2 { get; set; }
    }
}
