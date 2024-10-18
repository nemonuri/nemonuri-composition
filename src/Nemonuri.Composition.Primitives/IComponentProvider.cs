using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentProvider<T> : IComponentCollectionProvider, IProvider<T>
{
    T? Get(Func<T, bool>? predicate);
}
