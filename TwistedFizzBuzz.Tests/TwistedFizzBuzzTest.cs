namespace TwistedFizzBuzz.Tests
{
    public class TwistedFizzBuzzTest
    {
        [Fact]
        public void GenerateFizzBuzzRange_ValidRange_ReturnsExpectedResult()
        {
            // Arrange
            var fizzBuzzer = new FizzBuzzer();

            // Act
            var result = fizzBuzzer.GenerateFizzBuzzRange("1-15");

            // Assert
            var expectedResult = new[]
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11", "Fizz", "13", "14", "FizzBuzz"
            };
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GenerateFizzBuzzNonSequential_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var fizzBuzzer = new FizzBuzzer();

            // Act
            var result = fizzBuzzer.GenerateFizzBuzzNonSequential("3,5,15,7");

            // Assert
            var expectedResult = new[] { "Fizz", "Buzz", "FizzBuzz", "7" };
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GenerateCustomFizzBuzz_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var fizzBuzzer = new FizzBuzzer();

            // Act
            var result = fizzBuzzer.GenerateCustomFizzBuzz(1, 10, 2, 3, "Foo", "Bar");

            // Assert
            var expectedResult = new[] { "1", "Foo", "Bar", "Foo", "5", "FooBar", "7", "Foo", "Bar", "Foo" };
            Assert.Equal(expectedResult, result);
        }


        [Fact]
        public async Task GenerateApiFizzBuzz_InvalidUrl_ReturnsNumbers()
        {
            // Arrange
            var fizzBuzzer = new FizzBuzzer();
            // Use an invalid API URL for testing.
            string invalidApiUrl = "https://example.com/nonexistentapi";

            // Act
            var result = await fizzBuzzer.GenerateApiFizzBuzz(1, 5, invalidApiUrl);

            // Assert
            var expectedResults = new[] { "1", "2", "3", "4", "5" };
            Assert.Equal(expectedResults, result.ToList());
        }


        [Fact]
        public void GenerateFizzBuzzRange_InvalidRange_ReturnsEmptyList()
        {

        
            // Arrange
            var fizzBuzzer = new FizzBuzzer();

            // Act
            var result = fizzBuzzer.GenerateFizzBuzzRange("invalid-range");

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GenerateFizzBuzzNonSequential_InvalidInput_ReturnsEmptyList()
        {
            var fizzBuzzer = new FizzBuzzer();
            var result = fizzBuzzer.GenerateFizzBuzzNonSequential("invalid");
            Assert.Empty(result);
        }
    }
}