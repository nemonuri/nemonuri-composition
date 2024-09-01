

using System.Runtime.CompilerServices;

namespace Nemonuri.Composition;

#if false
public partial class SampleComponentServiceProvider : IComponentServiceProvider
{
    //ImmutableHashSet<T>.Builder

    Dictionary<Type, Lz>

    public object? GetService(Type serviceType)
    {
        if (serviceType == typeof(Exportables.CompA))
        {
            return 
        }
        
    }

    public IEnumerable<IProvider<T>> GetProviderSet<T>()
    {
        throw new NotImplementedException();
    }
}

partial class SampleComponentServiceProvider
{
    public static class Exportables
    {
        public class CompA(int value) : DefaultProvider<int>(value);
    }
}
#endif