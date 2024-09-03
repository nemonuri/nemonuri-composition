using System.Collections;

namespace Nemonuri.Composition;

public partial class SampleComponentServiceProvider : IComponentServiceProvider
{

    private readonly Dictionary<Type, Lazy<object>> _providerDictionary;
    private Dictionary<Type, ICollection<object>>? _providerSetDictionary;

    public SampleComponentServiceProvider()
    {
        _providerDictionary = new ()
        {
            {typeof(Exportables.CompA), new Lazy<object>(static () => new Exportables.CompA(1)) },
            {typeof(Exportables.CompB), new Lazy<object>(static () => new Exportables.CompB(2)) }
        };
    }

    private Dictionary<Type, ICollection<object>> ProviderSetDictionary => _providerSetDictionary ??= CreateProviderSetDictionary();

    private Dictionary<Type, ICollection<object>> CreateProviderSetDictionary()
    {
        Type[] keys = CreateKeyArray();

        Dictionary<Type, ICollection<object>> result = new();
        foreach (Type key in keys)
        {
            result.Add(key, Array.Empty<object>());
        }

        return result;
    }

    private Type[] CreateKeyArray()
    {
        Type[] keys = new Type[_providerDictionary.Count];
        lock (_providerDictionary)
        {
            _providerDictionary.Keys.CopyTo(keys, 0);
        }

        return keys;
    }

    public object? GetService(Type serviceType)
    {
        bool tryGetSuccessed;
        Lazy<object>? outLazy;

        lock (_providerDictionary)
        {
            tryGetSuccessed = _providerDictionary.TryGetValue(serviceType, out outLazy);
        }

        return tryGetSuccessed ? outLazy.Value : null;
    }

    public IEnumerable<IProvider<T>> GetProviderSet<T>()
    {
        var psd = ProviderSetDictionary; // 초기화 확인

        bool tryGetSuccessed;
        ICollection<object>? outCollection;

        lock (psd)
        {
            tryGetSuccessed = psd.TryGetValue(typeof(T), out outCollection);
        }

        if (outCollection.Count == 0) {}
        
        throw new NotImplementedException();
    }


}

partial class SampleComponentServiceProvider
{
    public static class Exportables
    {
        public class CompA(int value) : DefaultProvider<int>(value);
        public class CompB(int value) : DefaultProvider<int>(value);
    }
}