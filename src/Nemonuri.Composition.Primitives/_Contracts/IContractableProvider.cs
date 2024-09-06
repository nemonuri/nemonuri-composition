namespace Nemonuri.Composition;

public interface IContractableProvider<T> : IProvider<T>
{
    object? Contract {get;}
}
