namespace Nemonuri.Composition;

public interface IContractableProvider : IContract, IProvider
{
}

public interface IContractableProvider<T> : IContractableProvider, IProvider<T>
{
}