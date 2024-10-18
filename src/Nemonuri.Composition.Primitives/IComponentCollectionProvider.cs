using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentCollectionProvider : ICollectionProvider
{
    object? GetFirst(Func<object, bool>? predicate);
    IEnumerable Get(Func<object, bool>? predicate);
}

public interface IComponentCollectionProvider<T> : IComponentCollectionProvider, ICollectionProvider<T>
{
    T? GetFirst(Func<T, bool>? predicate);
    IEnumerable<T> Get(Func<T, bool>? predicate);
}