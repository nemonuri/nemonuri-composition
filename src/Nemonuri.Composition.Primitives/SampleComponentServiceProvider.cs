

namespace Nemonuri.Composition;

internal class SampleComponentServiceProvider : IComponentServiceProvider
{
    //ImmutableHashSet<T>.Builder
    public object? GetService(Type serviceType)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IProvider<T>> GetProviderSet<T>()
    {
        throw new NotImplementedException();
    }
}