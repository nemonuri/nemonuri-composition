namespace Nemonuri.Composition;

public class DefaultComponentServiceReceiver<T> : IComponentServiceReceiver<T, object>
{
    public DefaultComponentServiceReceiver() {}

    public object? Contract => null;
    public IEqualityComparer<object>? ContractEqualityComparer => null;
}

public class DefaultComponentServiceReceiver<T, TContract> : IComponentServiceReceiver<T, TContract>
{
    public DefaultComponentServiceReceiver(TContract? contract, IEqualityComparer<TContract>? contractEqualityComparer)
    {
        Contract = contract;
        ContractEqualityComparer = contractEqualityComparer;
    }

    public TContract? Contract { get; }
    public IEqualityComparer<TContract>? ContractEqualityComparer { get; }
}