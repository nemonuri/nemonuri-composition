using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Nemonuri.Composition;

internal partial class DefaultComponentCollectionProvider : IComponentCollectionProvider
{
    private readonly IReadOnlyDictionary<Type, IServiceProvider> _providerDict;
    private readonly IReadOnlyDictionary<Type, IServiceProvider> _collectionProviderDict;

    private DefaultComponentCollectionProvider
    (
        IReadOnlyDictionary<Type, IServiceProvider> providers,
        IReadOnlyDictionary<Type, IServiceProvider> collectionProviders
    )
    {
        _providerDict = providers;
        _collectionProviderDict = collectionProviders;
    }

    public T? GetFirstComponent<T>(Func<T, bool>? predicate)
    {
        if(_providerDict.TryGetValue(typeof(T), out IServiceProvider? provider))
        {
            if 
            (
                (provider is IComponentProvider<T> tProvider) &&
                (tProvider.GetComponent() is { } t) &&
                (predicate?.Invoke(t) ?? true)
            )
            {
                return t;
            }
        }

        if (_collectionProviderDict.TryGetValue(typeof(T), out IServiceProvider? collectionProvider))
        {
            if 
            (
                (collectionProvider is IComponentCollectionProvider<T> tCollectionProvider) &&
                (tCollectionProvider.GetComponents() is { } tCollection) &&
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

    public IEnumerable<T> GetComponents<T>(Func<T, bool>? predicate)
    {
        if(_providerDict.TryGetValue(typeof(T), out IServiceProvider? provider))
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

        if (_collectionProviderDict.TryGetValue(typeof(T), out IServiceProvider? collectionProvider))
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

    [RequiresDynamicCode("DefaultComponentCollectionProvider.GetService requires reflection")]
    public object? GetService(Type serviceType)
    {
        {
            if 
            (
                serviceType.IsConstructedGenericType &&
                (serviceType.GetGenericTypeDefinition() == typeof(IEnumerable<>)) &&
                _collectionProviderDict.TryGetValue(serviceType, out IServiceProvider? provider)
            )
            {
                return provider.GetService(serviceType);
            }
        }

        {
            if (_providerDict.TryGetValue(serviceType, out IServiceProvider? provider))
            {
                return provider.GetService(serviceType);
            }
        }

        return null;
    }
}
