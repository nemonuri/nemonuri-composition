using System.Collections;
using System.Collections.Immutable;

namespace Nemonuri.Composition;

using Primitives;

public partial class SampleComponentServiceProvider : IComponentServiceProvider
{

    public SampleComponentServiceProvider()
    {
        _providerDictionary = new ()
        {
            {typeof(Exportables.CompA), new Lazy<object>(static () => new Exportables.CompA(1)) },
            {typeof(Exportables.CompB), new Lazy<object>(static () => new Exportables.CompB(2)) }
        };
    }

    private readonly Dictionary<Type, Lazy<object>> _providerDictionary;

    private Type[]? _providerDictionaryKeys;
    private IReadOnlyList<Type> ProviderDictionaryKeys => 
        _providerDictionaryKeys ?? Interlocked.CompareExchange(ref _providerDictionaryKeys, CreateProviderDictionaryKeys(), null) ?? _providerDictionaryKeys;

    private Type[] CreateProviderDictionaryKeys()
    {
        Type[] keys = new Type[_providerDictionary.Count];
        lock (_providerDictionary)
        {
            _providerDictionary.Keys.CopyTo(keys, 0);
        }

        return keys;
    }

    private Dictionary<Type, IEnumerable>? _providerSetDictionary;
    private Dictionary<Type, IEnumerable> ProviderSetDictionary =>
        _providerSetDictionary ?? Interlocked.CompareExchange(ref _providerSetDictionary, CreateProviderSetDictionary(), null) ?? _providerSetDictionary;

    private Dictionary<Type, IEnumerable> CreateProviderSetDictionary()
    {
        return new Dictionary<Type, IEnumerable>();
    }

    public object? GetService(Type serviceType)
    {
        bool tryGetSuccessed;
        Lazy<object>? outLazy;

        lock (_providerDictionary)
        {
            tryGetSuccessed = _providerDictionary.TryGetValue(serviceType, out outLazy);
        }

        return tryGetSuccessed ? outLazy!.Value : null;
    }

    public IEnumerable<IContractableProvider<T>> GetProviderSet<T>()
    {
        var psd = ProviderSetDictionary; // Ensure Initialized

        bool tryGetSuccessed;
        IEnumerable? outCollection;

        lock (psd)
        {
            tryGetSuccessed = psd.TryGetValue(typeof(T), out outCollection);
        }

        if (tryGetSuccessed && outCollection is IEnumerable<IContractableProvider<T>> vProviders)
        {
            return vProviders;
        }

        ImmutableHashSet<IContractableProvider<T>>.Builder? builder = null;
        foreach (Type key in ProviderDictionaryKeys)
        {
            if 
            (
                typeof(IContractableProvider<T>).IsAssignableFrom(key) &&
                GetService(key) is IContractableProvider<T> vProvider
            )
            {
                builder ??= ImmutableHashSet.CreateBuilder<IContractableProvider<T>>();
                builder.Add(vProvider);
            }
        }

        if (builder != null)
        {
            ImmutableHashSet<IContractableProvider<T>> immutableHashSet = builder.ToImmutable();
            lock (psd)
            {
                psd.TryAdd(typeof(T), immutableHashSet);
            }
            return immutableHashSet;
        }
        
        return [];
    }
}

partial class SampleComponentServiceProvider
{
    public static class Exportables
    {
        public class CompA(int value) : DefaultContractableProvider<int>(value);
        public class CompB(int value) : DefaultContractableProvider<int>(value, "CompB");
    }
}