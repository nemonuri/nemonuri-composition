namespace Nemonuri.Composition.Primitives;

public interface IContractableProvider : IContract, IProvider
{
}

public interface IContractableProvider<T> : IContractableProvider, IProvider<T>
{
}
