using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentCollectionProvider : ICollectionProvider
{
    T? GetFirst<T>(Func<T, bool>? predicate);
    IEnumerable<T> Get<T>(Func<T, bool>? predicate);
}

public interface IComponentCollectionProvider<T> : IComponentCollectionProvider, ICollectionProvider<T>
{
    T? GetFirst(Func<T, bool>? predicate);
    IEnumerable<T> Get(Func<T, bool>? predicate);
}