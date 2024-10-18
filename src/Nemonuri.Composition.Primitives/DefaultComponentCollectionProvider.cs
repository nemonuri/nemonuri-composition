using System.Collections;

namespace Nemonuri.Composition;

internal partial class DefaultComponentCollectionProvider : IComponentCollectionProvider
{
    private readonly Dictionary<Type, IProvider> _providerDict;
    private readonly Dictionary<Type, ICollectionProvider> _collectionProviderDict;

    private DefaultComponentCollectionProvider
    (
        Dictionary<Type, IProvider> providers,
        Dictionary<Type, ICollectionProvider> collectionProviders
    )
    {
        _providerDict = providers;
        _collectionProviderDict = collectionProviders;
    }

    IEnumerable ICollectionProvider.GetCollection()
    {
        foreach (var provider in _providerDict.Values)
        {
            var item = provider.Get();
            if (item == null) {continue;}
            yield return item;
        }

        foreach (var collectionProvider in _collectionProviderDict.Values) //TODO
        foreach (var item in collectionProvider.GetCollection())
        {
            if (item == null) {continue;}
            yield return item;
        }
    }

    T? IComponentCollectionProvider.GetFirst<T>(Func<T, bool>? predicate) where T : default
    {
        if(_providerDict.TryGetValue(typeof(T), out IProvider? provider))
        {
            if 
            (
                (provider is IProvider<T> tProvider) &&
                (tProvider.Get() is { } t) &&
                (predicate?.Invoke(t) ?? true)
            )
            {
                return t;
            }
        }

        if (_collectionProviderDict.TryGetValue(typeof(T), out ICollectionProvider? collectionProvider))
        {
            if 
            (
                (collectionProvider is ICollectionProvider<T> tCollectionProvider) &&
                (tCollectionProvider.GetCollection() is { } tCollection) &&
                (
                    (predicate == null ? tCollection.FirstOrDefault() : tCollection.FirstOrDefault(predicate)) is { } t
                )
            )
            {
                return t;
            }
        }

        return default;
    }

    IEnumerable<T> IComponentCollectionProvider.Get<T>(Func<T, bool>? predicate)
    {
        if(_providerDict.TryGetValue(typeof(T), out IProvider? provider))
        {
            if 
            (
                (provider is IProvider<T> tProvider) &&
                (tProvider.Get() is { } t) &&
                (predicate?.Invoke(t) ?? true)
            )
            {
                yield return t;
            }
        }

        if (_collectionProviderDict.TryGetValue(typeof(T), out ICollectionProvider? collectionProvider))
        {
            if 
            (
                (collectionProvider is ICollectionProvider<T> tCollectionProvider) &&
                (tCollectionProvider.GetCollection() is { } tCollection)
            )
            {
                foreach (var t in tCollection)
                {
                    if
                    (
                        (t != null) &&
                        (predicate?.Invoke(t) ?? true)
                    )
                    {
                        yield return t;
                    }
                }
            }
        }
    }
}
