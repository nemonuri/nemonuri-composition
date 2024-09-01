
namespace Nemonuri.Composition;

public interface IComponentServiceProvider : IServiceProvider
{
    IEnumerable<IProvider<T>> GetProviderSet<T>();
}
