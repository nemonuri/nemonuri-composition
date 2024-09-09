
using System.Collections.Immutable;

namespace Nemonuri.Composition;

public partial class ComponentImporter : IComponentImporter
{
    private readonly ImmutableArray<IContractableReceiver> _contractableReceivers;

    public ComponentImporter():this([])
    {}

    public ComponentImporter(IEnumerable<IContractableReceiver> contractableReceivers)
    {
        Guard.IsNotNull(contractableReceivers);
        _contractableReceivers = contractableReceivers.ToImmutableArray();
    }

    public IEnumerable<IContractableReceiver> ContractableReceivers => _contractableReceivers;
}