using System.Collections;
using System.Collections.Immutable;

namespace Nemonuri.Composition;

using Primitives;

public partial class DefaultComponentServiceProvider : IComponentServiceProvider
{
    public static Builder CreateBuilder() =>
        new Builder();

    private readonly Dictionary<Type, Lazy<object>> _providerDictionary;

    private DefaultComponentServiceProvider(Dictionary<Type, Lazy<object>> providerDictionary)
    {
        Guard.IsNotNull(providerDictionary);
        _providerDictionary = providerDictionary;
    }

    public IEnumerable<IContractableProvider<T>> GetProviderSet<T>()
    {
        throw new NotImplementedException();
    }

    public object? GetService(Type serviceType)
    {
        throw new NotImplementedException();
    }
}
