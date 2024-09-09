using System.Collections.Immutable;

namespace Nemonuri.Composition;

public partial class ComponentExporter : IComponentExporter
{
    public static Builder CreateBuilder() => new ();

    private readonly Dictionary<Type, Lazy<IContractableProvider>> _providerDictionary;

    private ComponentExporter(Dictionary<Type, Lazy<IContractableProvider>> providerDictionary)
    {
        Guard.IsNotNull(providerDictionary);
        _providerDictionary = providerDictionary;
    }

    public Builder ToBuilder() => new Builder(_providerDictionary);

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

    private Dictionary<Type, IEnumerable<IContractableProvider>>? _providerSetDictionary;
    private Dictionary<Type, IEnumerable<IContractableProvider>> ProviderSetDictionary =>
        _providerSetDictionary ?? Interlocked.CompareExchange(ref _providerSetDictionary, CreateProviderSetDictionary(), null) ?? _providerSetDictionary;

    private Dictionary<Type, IEnumerable<IContractableProvider>> CreateProviderSetDictionary()
    {
        return new Dictionary<Type, IEnumerable<IContractableProvider>>();
    }

    public object? GetService(Type serviceType)
    {
        bool tryGetSuccessed;
        Lazy<IContractableProvider>? outLazy;

        lock (_providerDictionary)
        {
            tryGetSuccessed = _providerDictionary.TryGetValue(serviceType, out outLazy);
        }

        return tryGetSuccessed ? outLazy!.Value : null;
    }

    public IEnumerable<IContractableProvider> GetContractableProvidersByTypeContract(Type typeContract)
    {
        var psd = ProviderSetDictionary; // Ensure Initialized

        bool tryGetSuccessed;
        IEnumerable<IContractableProvider>? outCollection;

        lock (psd)
        {
            tryGetSuccessed = psd.TryGetValue(typeContract, out outCollection);
        }

        if (tryGetSuccessed && outCollection is IEnumerable<IContractableProvider> vProviders)
        {
            return vProviders;
        }

        ImmutableHashSet<IContractableProvider>.Builder? builder = null;
        foreach (Type key in ProviderDictionaryKeys)
        {
            if 
            (
                GetService(key) is IContractableProvider vProvider &&
                vProvider.TypeContract == typeContract
            )
            {
                builder ??= ImmutableHashSet.CreateBuilder<IContractableProvider>();
                builder.Add(vProvider);
            }
        }

        if (builder != null)
        {
            ImmutableHashSet<IContractableProvider> immutableHashSet = builder.ToImmutable();
            lock (psd)
            {
                psd.TryAdd(typeContract, immutableHashSet);
            }
            return immutableHashSet;
        }
        
        return [];
    }
}
