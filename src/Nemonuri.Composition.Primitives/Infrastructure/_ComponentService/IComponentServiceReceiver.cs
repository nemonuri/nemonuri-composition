namespace Nemonuri.Composition.Infrastructure;

public interface IComponentServiceReceiver
{
    IEnumerable<IContractableReceiver> ContractableReceivers {get;}
}
