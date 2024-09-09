
using System.Collections.Immutable;

namespace Nemonuri.Composition;

public partial class DefaultComponentServiceReceiver : IComponentServiceReceiver
{
    private readonly ImmutableArray<IContractableReceiver> _contractableReceivers;

    public DefaultComponentServiceReceiver():this([])
    {}

    public DefaultComponentServiceReceiver(IEnumerable<IContractableReceiver> contractableReceivers)
    {
        Guard.IsNotNull(contractableReceivers);
        _contractableReceivers = contractableReceivers.ToImmutableArray();
    }

    public IEnumerable<IContractableReceiver> ContractableReceivers => _contractableReceivers;
}