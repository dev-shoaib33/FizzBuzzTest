using System;
using TwistedFizzBuzz;

class Program
{
    static void Main(string[] args)
    {
        var fizzBuzzer = new FizzBuzzer();

        for (int i = -20; i <= 127; i++)
        {
            List<string> output = fizzBuzzer.GenerateCustomFizzBuzz(i, i, 5, 9, "Fizz", "Buzz");

            if (i % 27 == 0)
            {
                output.Add("Bar");
            }

            if (output.Count > 1)
            {
                Console.WriteLine(string.Join("", output));
            }
            else if (output.Count == 1)
            {
                Console.WriteLine(output[0]);
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}
