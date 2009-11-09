namespace MyService
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculator _calculator;

        public CalculationService(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Add(int num1, int num2)
        {
            return _calculator.Add(num1, num2);
        }
    }
}