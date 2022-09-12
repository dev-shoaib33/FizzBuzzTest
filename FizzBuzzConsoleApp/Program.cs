using System;
using TwistedFizzBuzz;

namespace FizzBuzzConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the FizzBuzzer class from the TwistedFizzBuzz library
            var fizzBuzzer = new FizzBuzzer();

            // Generate FizzBuzz output for the standard problem (numbers from 1 to 100)
            var fizzBuzzOutput = fizzBuzzer.GenerateFizzBuzzRange("1-100");

            // Print the FizzBuzz output to the console
            foreach (var item in fizzBuzzOutput)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine(); // Pause to see the output (you can remove this if not needed)
        }
    }
}
