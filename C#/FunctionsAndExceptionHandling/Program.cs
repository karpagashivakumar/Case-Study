using System;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Factorial
            Console.Write("Enter number to find factorial: ");
            int num = int.Parse(Console.ReadLine());
            int fact = Methods.CalculateFactorial(num);
            Console.WriteLine($"Factorial of {num} is {fact}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in factorial calculation: {ex.Message}");
        }

        try
        {
            // 2. Simple Interest
            Console.Write("\nEnter Principal: ");
            double p1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double r1 = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double t1 = double.Parse(Console.ReadLine());

            double si1 = Methods.CalculateSimpleInterest(p1, r1, t1);
            Console.WriteLine($"Simple Interest: {si1}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in simple interest calculation: {ex.Message}");
        }

        try
        {
            // 3. Simple Interest using out parameters
            Console.Write("\nEnter Principal: ");
            double p2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Rate: ");
            double r2 = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double t2 = double.Parse(Console.ReadLine());

            double interest, total;
            Methods.CalculateInterestWithOut(p2, r2, t2, out interest, out total);
            Console.WriteLine($"Interest: {interest}, Total Payable: {total}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in out parameter interest calculation: {ex.Message}");
        }

        try
        {
            // 4. Simple Interest with optional parameter
            Console.Write("\nEnter Principal: ");
            double p3 = double.Parse(Console.ReadLine());
            Console.Write("Enter Time: ");
            double t3 = double.Parse(Console.ReadLine());

            double si2 = Methods.CalculateInterestOptional(p3, t3); // Uses default rate = 10
            Console.WriteLine($"Simple Interest (Default Rate=10): {si2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in optional parameter interest calculation: {ex.Message}");
        }
    }
}