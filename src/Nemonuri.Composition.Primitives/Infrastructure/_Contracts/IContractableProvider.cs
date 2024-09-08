namespace Nemonuri.Composition.Infrastructure;

public interface IContractableProvider : IContract, IProvider
{
}

public interface IContractableProvider<T> : IContractableProvider, IProvider<T>
{
}
