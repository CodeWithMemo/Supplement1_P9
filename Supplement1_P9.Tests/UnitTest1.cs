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
    
}