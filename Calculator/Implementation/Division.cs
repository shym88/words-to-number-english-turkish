using Calculator.Interface;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Implementation
{
    class Division : ICalculator
    {
        long ICalculator.Calculate(CalculatorParams paramaters)
        {
            if(paramaters.parameter_1==0 || paramaters.parameter_2 == 0)
                throw new ApplicationException("err-05");
            return paramaters.parameter_1 / paramaters.parameter_2;
        }
    }
}
