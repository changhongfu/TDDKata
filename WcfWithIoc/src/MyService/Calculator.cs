using System;

namespace MyService
{
    public class Calculator : ICalculator
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}