
namespace Nemonuri.Composition.Infrastructure;


public interface IComponentServiceProvider : IServiceProvider
{
    IEnumerable<IContractableProvider> GetContractableProvidersByTypeContract(Type typeContract);
}
