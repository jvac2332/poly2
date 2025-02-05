// See https://aka.ms/new-console-template for more information

using System;
using System.Xml.Schema;

class PolynoimalCalculator
{
    static void  Main()
    
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("                 Polynoimal CalculatorV1.0        ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(" This Calculator calculates the value of the polynomials up to degree 3.");

        bool runAgain = true; // It acts as a loop control variable—as long as runAgain is true, the program will keep running.
        int polynomialCount = 1; // It keeps the integer variable track on how many polys the user has put it in


        while (runAgain)
        {
            Console.WriteLine($"\nEnter the information for the polynomial #{polynomialCount} polynomial(s).");
            int degree = GetDegree(); // The function ask the user to enter the polynomial degree
            double[] coefficients = GetCoefficients(degree); 
            (int minX, int maxX) = GetDomain();// It class which the user to enter the min and max x values for the table 

            PrintPolynomial(degree, coefficients);
            PrintTable(degree, coefficients, minX, maxX);

            runAgain = AskToContinue();// The code deteremines if it should run again with user input
            polynomialCount++; 
        }
        
        Console.WriteLine("\nThat was so crazy fun I bet you got dizzy");
    }

    static int GetDegree()
    {
        while (true)
        {
            Console.WriteLine("Enter the degree of the polynomial (0-3): ");
            if (int.TryParse(Console.ReadLine(), out int degree) && degree >= 0 && degree <= 3)
                return degree;
            Console.WriteLine("Invalid degree. The degree must be in the integers of between (0-3): ");
        }
    }

    static double[] GetCoefficients(int degree)
    {
        double[] coeffiecients = new double[degree + 1];
        for (int i = degree; i >= 0; i--) // This loop is a process of each coefficient of a polynomial from the degree term 
        {
            while (true)
            {
                Console.Write($"Enter the coeffiecent for x^{i}: ");
                if (double.TryParse(Console.ReadLine(), out double coeffiecient))
                {
                    coeffiecients[i] = coeffiecient;
                    break;
                    
                }
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
        return coeffiecients;
    }

    static (int, int) GetDomain() // The return of values for the mins and max value 
    {
        int minX, maxX;
        while (true)
        {
            Console.Write("Enter the min x: ");
            if (int.TryParse(Console.ReadLine(), out minX)) // Converts the user input into an integer
                break;
            Console.WriteLine("Invalid input, please enter interger value.");
        }

        while (true)
        {
            Console.Write("Enter the max x: ");
            if (int.TryParse(Console.ReadLine(), out maxX))
                break;
            Console.WriteLine("Invalid input, please enter interger value.");
        }

        if (minX > maxX)
        {           // line 87-91 ensures the polynomial is always looked at from the smallest x-value
            (minX, maxX) = (maxX, minX);
        }
        return (minX, maxX);
    }

    static void PrintPolynomial(int degree, double[] coefficients)
    {
        Console.Write("Function: f(x) = ");
        bool firstTerm = true;
        for (int i = degree; i >= 0; i--)
        {
            if (coefficients[i] != 0)
            {
                if (!firstTerm)
                    Console.Write(coefficients[i] > 0 ? "+" : "-");
                Console.Write(Math.Abs(coefficients[i]) + (i > 0 ? $@"x^{i}": ""));
                firstTerm = false;// Ensures that after the first printed term, all subsequent term to properly print 
            }
        }
        Console.WriteLine();
    }

    static void PrintTable(int degree, double[] coefficients, int minX, int maxX)
    {
        Console.WriteLine("\nHere is the polynomial table over the domain: ");
        Console.WriteLine("x     y");
        Console.WriteLine("--------------");

        for (int x = minX; x <= maxX; x++)
        {
            double y = 0;
            for (int i = 0; i <= degree; i++)
            {
                y += coefficients[i] * Math.Pow(x, i);
            }
            Console.WriteLine($"{x, -5} {y,8 }");
        }
    }

    static bool AskToContinue()
    {
        while (true)
        {
            Console.WriteLine("\nDo you want to compute another polynomial (y or n)? ");
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "y") return true;
            if (input == "n") return false;
            Console.WriteLine("Invalid input. Please enter a 'y' or 'n'.");
        }
    }
        
}









