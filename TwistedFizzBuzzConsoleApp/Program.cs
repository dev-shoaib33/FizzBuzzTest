using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwistedFizzBuzz;

class Program
{
    static async Task Main(string[] args)
    {
        var fizzBuzzer = new FizzBuzzer();

        // 1. Generate FizzBuzz for a range of numbers
        List<string> rangeFizzBuzz = fizzBuzzer.GenerateFizzBuzzRange("1-20");
        Console.WriteLine("FizzBuzz for the range 1-20:");
        Console.WriteLine(string.Join(", ", rangeFizzBuzz));

        // 2. Generate FizzBuzz for non-sequential numbers
        List<string> nonSequentialFizzBuzz = fizzBuzzer.GenerateFizzBuzzNonSequential("1,3,5,15,20");
        Console.WriteLine("\nFizzBuzz for non-sequential numbers 1,3,5,15,20:");
        Console.WriteLine(string.Join(", ", nonSequentialFizzBuzz));

        // 3. Generate Custom FizzBuzz
        List<string> customFizzBuzz = fizzBuzzer.GenerateCustomFizzBuzz(10, 30, 3, 5, "Mcdonalds", "Kentucky Chicken");
        Console.WriteLine("\nCustom FizzBuzz for the range 10-30 with divisors 3 and 5:");
        Console.WriteLine(string.Join(", ", customFizzBuzz));

        // 4. Generate FizzBuzz using an API
        string apiUrl = "https://rich-red-cocoon-veil.cyclic.app/random";
        List<string> apiFizzBuzz = await fizzBuzzer.GenerateApiFizzBuzz(1, 30, apiUrl);
        Console.WriteLine("\nFizzBuzz using API for the range 1-500:");
        Console.WriteLine(string.Join(", ", apiFizzBuzz));
    }
}
