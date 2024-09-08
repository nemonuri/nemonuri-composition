using System.Collections;

namespace Nemonuri.Composition.Infrastructure;

public interface IContractableReceiver : IContract, IReceiver
{
    IEqualityComparer? AdditionalContractEqualityComparer {get;}
}

public interface IContractableReceiver<T> : IContractableReceiver, IReceiver<T>
{
}
