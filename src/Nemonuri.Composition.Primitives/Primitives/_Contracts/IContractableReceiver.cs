using System.Collections;

namespace Nemonuri.Composition.Primitives;

public interface IContractableReceiver : IContract, IReceiver
{
    IEqualityComparer? AdditionalContractEqualityComparer {get;}
}

public interface IContractableReceiver<T> : IContractableReceiver, IReceiver<T>
{
}
