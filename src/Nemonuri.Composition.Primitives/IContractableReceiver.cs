using System.Collections;

namespace Nemonuri.Composition;

public interface IContractableReceiver : IContract, IReceiver
{
    IEqualityComparer? AdditionalContractEqualityComparer {get;}
}

public interface IContractableReceiver<T> : IContractableReceiver, IReceiver<T>
{
}
