namespace Nemonuri.Composition.Primitives;

public class DefaultContractableProvider<T> : IContractableProvider<T>
{
    private readonly T _value;

    public DefaultContractableProvider(T value, object? contract = null)
    {
        _value = value;
        Contract = contract;
    }

    public object? Contract { get; }

    public T Get() => _value;
}