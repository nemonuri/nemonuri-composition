namespace Nemonuri.Composition.Primitives;

public interface IContractableProvider<T> : IProvider<T>
{
    object? Contract {get;}
}
