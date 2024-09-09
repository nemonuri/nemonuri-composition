using Nemonuri.Composition.Infrastructure;

namespace Nemonuri.Composition.Test.Models;

public partial class ConsoleWriteLineAppAddOn : IComponentServiceProvider
{
    private readonly DefaultComponentServiceProvider _source;

    public ConsoleWriteLineAppAddOn
    (
        string? vComponentANull = null,
        string? vComponentA0 = null,
        string? vComponentA1 = null,
        string? vComponentA2 = null,
        string? vComponentA3 = null,
        string? vComponentA4 = null,
        string? vComponentA5 = null
    )
    {
        _source = DefaultComponentServiceProvider.CreateBuilder()
            .Add<Exportable.ComponentANull, string?>(() => new (vComponentANull))
            .Add<Exportable.ComponentA0, string?>(() => new (vComponentA0))
            .Add<Exportable.ComponentA1, string?>(() => new (vComponentA1))
            .Add<Exportable.ComponentA2, string?>(() => new (vComponentA2))
            .Add<Exportable.ComponentA3, string?>(() => new (vComponentA3))
            .Add<Exportable.ComponentA4, string?>(() => new (vComponentA4))
            .Add<Exportable.ComponentA5, string?>(() => new (vComponentA5))
            .Build()
            ;
    }

    public IEnumerable<IContractableProvider> GetContractableProvidersByTypeContract(Type typeContract) =>
        _source.GetContractableProvidersByTypeContract(typeContract);
        
    public object? GetService(Type serviceType) => _source.GetService(serviceType);
}