using Calculator.Interface;
using Calculator.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Implementation
{
    class Addition : ICalculator
    {
        long ICalculator.Calculate(CalculatorParams paramaters)
        {
            return paramaters.parameter_1 + paramaters.parameter_2;
        }
    }
}
