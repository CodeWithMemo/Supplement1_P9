namespace Supplement1_P9;

public class InvalidSequenceException : Exception
{
    public InvalidSequenceException(string message) : base(message) { }
}

public class RandomFloatGenerator : IEnumerable<double>
{
    private Random _random = new Random();

    public IEnumerator<double> GetEnumerator()
    {
        int count = 0;
        while (true)
        {
            double number = _random.NextDouble();
            yield return number;

            if (number <= 0.5)
                count++;
            else
                count = 0;

            if (count >= 3)
                throw new InvalidSequenceException("Three consecutive numbers were ≤ 0.5.");
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}