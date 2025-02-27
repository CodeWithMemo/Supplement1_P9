namespace Supplement1_P9.Tests;

public class UnitTest1
{
    [Fact]
    public void RandomFloatGeneratorShouldThrowInvalidSequenceException()
    {
        var generator = new RandomFloatGenerator();
        var enumerator = generator.GetEnumerator();
        
        try
        {
            for (int i = 0; i < 1000; i++)
                enumerator.MoveNext();
        }
        catch (InvalidSequenceException)
        {
            Assert.True(true);
            return;
        }

        Assert.False(true, "Expected InvalidSequenceException to be thrown.");
    }
}

public class QuarterTests
{
    [Fact]
    public void QuarterEqualityShouldBeTrueForSameQuarter()
    {
        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.2);
        var q3 = new Quarter(0.3);

        Assert.True(q1 == q2);
        Assert.False(q1 == q3);
    }

    [Fact]
    public void QuarterComparisonsShouldWorkCorrectly()
    {
        var q1 = new Quarter(0.1);
        var q2 = new Quarter(0.4);
        
        Assert.True(q1 < q2);
        Assert.False(q2 < q1);
        Assert.True(q2 > q1);
    }
}