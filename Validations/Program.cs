using System;

/// <summary>
/// This program demonstrates exception handling for input validation scenarios.
/// </summary>
class InputValidationProgram
{
    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter an integer:");
            string input1 = Console.ReadLine();
            int number1 = ConvertToInt(input1);

            Console.WriteLine("Enter a decimal number:");
            string input2 = Console.ReadLine();
            decimal number2 = ConvertToDecimal(input2);

            Console.WriteLine("Enter a boolean value (true or false):");
            string input3 = Console.ReadLine();
            bool value = ConvertToBoolean(input3);

            int sum = AddNumbers(number1, (int)number2);
            Console.WriteLine($"The sum of the numbers is: {sum}");

            bool negation = NegateBoolean(value);
            Console.WriteLine($"The negation of the boolean value is: {!negation}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid value.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Input value is too large or too small to convert.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Division by zero is not allowed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    /// <summary>
    /// Converts a string to an integer value.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The converted integer value.</returns>
    static int ConvertToInt(string input)
    {
        return int.Parse(input);
    }

    /// <summary>
    /// Converts a string to a decimal value.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The converted decimal value.</returns>
    static decimal ConvertToDecimal(string input)
    {
        return decimal.Parse(input);
    }

    /// <summary>
    /// Converts a string to a boolean value.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The converted boolean value.</returns>
    static bool ConvertToBoolean(string input)
    {
        return bool.Parse(input);
    }

    /// <summary>
    /// Adds two numbers.
    /// </summary>
    /// <param name="number1">The first number.</param>
    /// <param name="number2">The second number.</param>
    /// <returns>The sum of the numbers.</returns>
    static int AddNumbers(int number1, int number2)
    {
        return number1 + number2;
    }

    /// <summary>
    /// Negates a boolean value.
    /// </summary>
    /// <param name="value">The boolean value.</param>
    /// <returns>The negated boolean value.</returns>
    static bool NegateBoolean(bool value)
    {
        return !value;
    }
}
