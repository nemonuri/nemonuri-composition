using System.Collections;

namespace Nemonuri.Composition;

public class DefaultComponentCollectionProvider : IComponentCollectionProvider
{
    object? IComponentCollectionProvider.GetFirst(Func<object, bool>? predicate)
    {
        throw new NotImplementedException();
    }

    IEnumerable IComponentCollectionProvider.Get(Func<object, bool>? predicate)
    {
        throw new NotImplementedException();
    }

    IEnumerable ICollectionProvider.GetCollection()
    {
        throw new NotImplementedException();
    }
}