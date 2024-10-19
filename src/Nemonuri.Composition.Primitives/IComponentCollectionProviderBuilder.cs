namespace Nemonuri.Composition;

public interface IComponentCollectionProviderBuilder
{
    IComponentCollectionProviderBuilder AddComponentProvider<T>(IComponentProvider<T> provider);

    IComponentCollectionProviderBuilder AddComponentCollectionProvider<T>(IComponentCollectionProvider<T> provider);

    IComponentCollectionProvider Build();
}