using System;
using System.Collections.Generic;

namespace TwistedFizzBuzz
{
    public class FizzBuzzer
    {

        private readonly HttpClient _httpClient;

        public FizzBuzzer()
        {
            _httpClient = new HttpClient();
        }

        public List<string> GenerateFizzBuzzRange(string inputRange, int divisor1 = 3, int divisor2 = 5, string token1 = "Fizz", string token2 = "Buzz")
        {
            var result = new List<string>();

            // Parse the input range
            if (TryParseRange(inputRange, out int start, out int end))
            {
                for (int i = start; i <= end; i++)
                {
                    string output = "";

                    if (i % divisor1 == 0) output += token1;
                    if (i % divisor2 == 0) output += token2;

                    if (string.IsNullOrEmpty(output)) output = i.ToString();

                    result.Add(output);
                }
            }
            else
            {
                // Handle invalid input range
                Console.WriteLine("Invalid input range. Please use the format 'start-end'.");
            }

            return result;
        }

        private bool TryParseRange(string inputRange, out int start, out int end)
        {
            start = 0;
            end = 0;

            // Split the input by the '-' character
            string[] rangeParts = inputRange.Split('-');

            if (rangeParts.Length == 2 && int.TryParse(rangeParts[0], out start) && int.TryParse(rangeParts[1], out end))
            {
                return true;
            }

            return false;
        }

        public List<string> GenerateFizzBuzzNonSequential(string inputNumbers, int divisor1 = 3, int divisor2 = 5, string token1 = "Fizz", string token2 = "Buzz")
        {
            var result = new List<string>();

            // Parse the input numbers
            string[] numberStrings = inputNumbers.Split(',');

            foreach (string numberString in numberStrings)
            {
                if (int.TryParse(numberString, out int number))
                {
                    string output = "";

                    if (number % divisor1 == 0) output += token1;
                    if (number % divisor2 == 0) output += token2;

                    if (string.IsNullOrEmpty(output)) output = number.ToString();

                    result.Add(output);
                }
                else
                {
                    // Handle invalid input
                    Console.WriteLine($"Invalid number: {numberString}");
                }
            }

            return result;
        }


        public List<string> GenerateCustomFizzBuzz(int start, int end, int divisor1, int divisor2, string token1, string token2)
        {
            var result = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string output = "";

                if (i % divisor1 == 0) output += token1;
                if (i % divisor2 == 0) output += token2;

                if (string.IsNullOrEmpty(output)) output = i.ToString();

                result.Add(output);
            }

            return result;
        }


        public async Task<List<string>> GenerateApiFizzBuzz(int start, int end, string apiUrl)
        {
            var result = new List<string>();

            for (int i = start; i <= end; i++)
            {
                string output = await GetApiFizzBuzzOutput(apiUrl);

                if (!string.IsNullOrEmpty(output))
                {
                    result.Add(output);
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        private async Task<string> GetApiFizzBuzzOutput(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic? apiResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                    int multiple = apiResponse?.multiple;
                    string? word = apiResponse?.word;

                    if (multiple != 0 && !string.IsNullOrEmpty(word) && multiple != 1)
                    {
                        return word;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle API request errors
                Console.WriteLine("API request error: " + ex.Message);
            }

            return "";
        }

    }
}
