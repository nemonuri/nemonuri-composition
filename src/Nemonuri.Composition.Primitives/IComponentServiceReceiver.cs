namespace Nemonuri.Composition;

public interface IComponentImporter
{
    IEnumerable<IContractableReceiver> ContractableReceivers {get;}
}
