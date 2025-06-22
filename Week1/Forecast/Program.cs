using System;
using System.Collections.Generic;
using System.Linq;

public class FinancialForecast
{
    // Calculates simple moving average of last 'period' values
    public static double CalculateMovingAverage(List<double> values, int period)
    {
        if (values.Count < period)
            throw new ArgumentException("Not enough data for the given period.");

        double sum = 0;
        for (int i = values.Count - period; i < values.Count; i++)
        {
            sum += values[i];
        }

        return sum / period;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Simulated monthly revenue in thousands
        List<double> revenue = new List<double> { 120, 130, 140, 150, 160, 170 };

        Console.Write("Enter number of months to average (e.g., 3): ");
        string? input = Console.ReadLine();
        int period = int.TryParse(input, out int p) ? p : 3;

        try
        {
            double forecast = FinancialForecast.CalculateMovingAverage(revenue, period);
            Console.WriteLine($"Forecasted revenue (next month): {forecast:F2}K");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

