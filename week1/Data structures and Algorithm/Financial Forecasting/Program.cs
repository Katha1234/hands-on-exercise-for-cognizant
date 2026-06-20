using System;

namespace FinancialForecasting
{
    class Program
    {
        // Recursive algorithm to calculate future value given growth rate
        public static double CalculateFutureValue(double currentValue, double growthRate, int periods)
        {
            // Base Case: No more time periods left
            if (periods <= 0)
                return currentValue;

            // Recursive Case: Calculate value for next period
            return CalculateFutureValue(currentValue * (1 + growthRate), growthRate, periods - 1);
        }

        static void Main(string[] args)
        {
            double currentAssetValue = 1000.00; // Starting value
            double annualGrowthRate = 0.05;     // 5% growth
            int forecastYears = 5;              // 5 years into the future

            Console.WriteLine($"--- Financial Forecasting (Exercise 7) ---");
            Console.WriteLine($"Initial Value: ${currentAssetValue:F2}");
            Console.WriteLine($"Growth Rate: {annualGrowthRate * 100}% annually");
            Console.WriteLine($"Forecasting Period: {forecastYears} years");

            double predictedValue = CalculateFutureValue(currentAssetValue, annualGrowthRate, forecastYears);
            Console.WriteLine($"\nPredicted Future Value: ${predictedValue:F2}");
        }
    }
}