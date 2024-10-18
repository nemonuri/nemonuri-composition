namespace Nemonuri.Composition;

public interface IComponentCollectionProviderBuilder
{
    IComponentCollectionProviderBuilder AddProvider<T>(IComponentProvider<T> provider);

    IComponentCollectionProviderBuilder AddCollectionProvider<T>(IComponentCollectionProvider<T> provider);

    IComponentCollectionProvider Build();
}