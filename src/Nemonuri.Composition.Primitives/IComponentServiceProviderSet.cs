namespace Nemonuri.Composition;

public interface IComponentServiceProviderSet : IComponentServiceProvider, IEnumerable<IComponentServiceProvider>
{
}