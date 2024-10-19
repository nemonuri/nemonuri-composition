using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentCollectionProvider : IServiceProvider
{
    T? GetFirstComponent<T>(Func<T, bool>? predicate);
    IEnumerable<T> GetComponents<T>(Func<T, bool>? predicate);
}

public interface IComponentCollectionProvider<T> : IComponentCollectionProvider
{
    IEnumerable<T> GetComponents(Func<T, bool>? predicate);
}