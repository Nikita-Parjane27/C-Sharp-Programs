// Install: dotnet add package NUnit
// dotnet add package NUnit3TestAdapter
// dotnet add package Microsoft.NET.Test.Sdk

using NUnit.Framework;

public class MathHelper
{
    public int Square(int n) => n * n;
    public bool IsEven(int n) => n % 2 == 0;
    public int Max(int a, int b) => a > b ? a : b;
}

[TestFixture]
public class MathHelperTests
{
    private MathHelper _math;

    [SetUp]
    public void Setup()
    {
        _math = new MathHelper();
    }

    [Test]
    public void Square_Of5_Returns25()
    {
        int result = _math.Square(5);
        Assert.AreEqual(25, result);
    }

    [Test]
    public void IsEven_For4_ReturnsTrue()
    {
        bool result = _math.IsEven(4);
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEven_For3_ReturnsFalse()
    {
        bool result = _math.IsEven(3);
        Assert.IsFalse(result);
    }

    [Test]
    public void Max_Returns_LargerNumber()
    {
        int result = _math.Max(10, 20);
        Assert.AreEqual(20, result);
    }

    [TearDown]
    public void TearDown()
    {
        _math = null;
    }
}