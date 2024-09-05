
namespace Nemonuri.Composition;

public interface IComponentServiceProvider : IServiceProvider
{
    IEnumerable<IContractableProvider<T>> GetProviderSet<T>();
}
