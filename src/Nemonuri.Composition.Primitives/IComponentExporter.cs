
namespace Nemonuri.Composition;


public interface IComponentExporter : IServiceProvider
{
    IEnumerable<IContractableProvider> GetContractableProvidersByTypeContract(Type typeContract);
}
