
using System.Collections;

namespace Nemonuri.Composition;

public class ContractableProvider<T> : IContractableProvider<T>
{
    private readonly T? _value;

    public ContractableProvider(T? value, object? additionalContract = null)
    {
        _value = value;
        AdditionalContract = additionalContract;
    }

    public Type TypeContract => typeof(T);

    public object? AdditionalContract {get;}

    public T? Get() => _value;
    object? IProvider.Get() => Get();
}
