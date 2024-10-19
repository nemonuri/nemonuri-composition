using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentCollectionProvider : IServiceProvider
{
    T? GetFirst<T>(Func<T, bool>? predicate);
    IEnumerable<T> Get<T>(Func<T, bool>? predicate);
}

public interface IComponentCollectionProvider<T> : IComponentCollectionProvider, ICollectionProvider<T>
{
    IEnumerable<T> Get(Func<T, bool>? predicate);
}