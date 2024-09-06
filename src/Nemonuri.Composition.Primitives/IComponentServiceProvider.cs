
namespace Nemonuri.Composition;

using Primitives;

public interface IComponentServiceProvider : IServiceProvider
{
    IEnumerable<IContractableProvider> GetContractableProviders(Type type);
}
