using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentCollectionProvider : IServiceProvider
{
    T? GetFirstComponent<T>(Func<T, bool>? predicate = null);
    IEnumerable<T> GetComponents<T>(Func<T, bool>? predicate = null);
}

public interface IComponentCollectionProvider<T> : IComponentCollectionProvider
{
    IEnumerable<T> GetComponents();
}