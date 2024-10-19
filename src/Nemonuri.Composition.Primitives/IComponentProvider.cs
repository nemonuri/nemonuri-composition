using System.Collections;

namespace Nemonuri.Composition;

public interface IComponentProvider<T> : IComponentCollectionProvider
{
    T? GetComponent();
}
