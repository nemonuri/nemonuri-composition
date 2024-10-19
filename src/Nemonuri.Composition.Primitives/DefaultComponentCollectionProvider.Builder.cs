namespace Nemonuri.Composition;

partial class DefaultComponentCollectionProvider
{
    internal class Builder() : IComponentCollectionProviderBuilder
    {
        private Dictionary<Type, IServiceProvider> _providers = new();
        private Dictionary<Type, IServiceProvider> _collectionProviders = new();

        public IComponentCollectionProviderBuilder AddProvider<T>(IComponentProvider<T> provider)
        {
            _providers.Add(typeof(T), provider);
            return this;
        }

        public IComponentCollectionProviderBuilder AddCollectionProvider<T>(IComponentCollectionProvider<T> provider)
        {
            _collectionProviders.Add(typeof(T), provider);
            return this;
        }

        public IComponentCollectionProvider Build()
        {
            return new DefaultComponentCollectionProvider(_providers, _collectionProviders);
        }
    }
}
