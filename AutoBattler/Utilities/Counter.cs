
public class Counter
{
    public int Value { get; private set; } = 0;

    public void Reset() => Value = 0;

    public void Increment() => Value++;

    public static implicit operator int(Counter counter) => counter.Value;
}
