using System;

public static class Methods
{
    // 1. Factorial using Function
    public static int CalculateFactorial(int number)
    {
        if (number < 0)
            throw new ArgumentException("Number must be non-negative.");

        int result = 1;
        for (int i = 2; i <= number; i++)
            result *= i;

        return result;
    }

    // 2. Simple Interest using Function
    public static double CalculateSimpleInterest(double principal, double rate, double time)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Inputs must be non-negative.");

        return (principal * rate * time) / 100;
    }

    // 3. Simple Interest and Total Payable using out parameters
    public static void CalculateInterestWithOut(double principal, double rate, double time, out double interest, out double totalAmount)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Inputs must be non-negative.");

        interest = (principal * rate * time) / 100;
        totalAmount = principal + interest;
    }

    // 4. Simple Interest using Optional Parameter
    public static double CalculateInterestOptional(double principal, double time, double rate = 10)
    {
        if (principal < 0 || rate < 0 || time < 0)
            throw new ArgumentException("Inputs must be non-negative.");

        return (principal * rate * time) / 100;
    }
}
