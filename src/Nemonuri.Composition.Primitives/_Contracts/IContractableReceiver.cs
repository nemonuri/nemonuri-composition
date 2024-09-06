namespace Nemonuri.Composition;

public interface IContractableReceiver<T, TContract> : IReceiver<T>
{
    TContract? Contract {get;}
    
    IEqualityComparer<TContract>? ContractEqualityComparer {get;}
}