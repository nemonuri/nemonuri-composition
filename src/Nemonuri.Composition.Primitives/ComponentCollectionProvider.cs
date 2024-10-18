namespace Nemonuri.Composition;

public static class ComponentCollectionProvider
{
    public static IComponentCollectionProviderBuilder CreateBuilder() => new DefaultComponentCollectionProvider.Builder();
}