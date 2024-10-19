using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentProvider<T> : IComponentCollectionProvider, IProvider<T>
{
    T? GetComponent(Func<T, bool>? predicate);
}
