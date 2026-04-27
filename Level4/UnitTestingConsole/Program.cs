// Create a separate test project:
// dotnet new xunit -n MyApp.Tests
// dotnet add reference ../MyApp/MyApp.csproj


// CalculatorTests.cs (in test project)
using Xunit;

public class CalculatorTests
{
    private readonly Calculator _calc = new Calculator();

    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectSum()
    {
        int result = _calc.Add(5, 3);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectResult()
    {
        int result = _calc.Subtract(10, 4);
        Assert.Equal(6, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(4, 5, 20)]
    [InlineData(0, 10, 0)]
    public void Multiply_MultipleInputs_ReturnsCorrectResult(int a, int b, int expected)
    {
        int result = _calc.Multiply(a, b);
        Assert.Equal(expected, result);
    }
}