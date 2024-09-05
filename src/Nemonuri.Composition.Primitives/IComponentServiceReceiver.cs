namespace Nemonuri.Composition;

public interface IComponentServiceReceiver<T, TContract>
{
    TContract? Contract {get;}

    IEqualityComparer<TContract>? ContractEqualityComparer {get;}
}
