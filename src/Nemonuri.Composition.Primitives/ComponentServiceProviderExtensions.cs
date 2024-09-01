namespace Nemonuri.Composition;

using Primitives;

public static class ComponentServiceProviderExtensions
{
    public static T? ReceiveService<TProvider, T>(this IComponentServiceProvider provider) where TProvider : IProvider<T>
    {
        var p = provider.GetService<TProvider>();
        if (p == null) {return default;};
        return p.Get();
    }

    // Receive Service From IProvider (First)
    public static T? ReceiveService<T>(this IComponentServiceProvider provider, Func<IProvider<T>, T, bool>? predicate = null)
    {
        foreach(var pv in provider.GetService<IReadOnlyProviderSetDictionary>()?[typeof(T)] ?? [])
        {
            if (pv is IProvider<T> pvt)
            {
                T t = pvt.Get();
                if (predicate?.Invoke(pvt, t) ?? true)
                {
                    return t;
                }
            }
        }
        return default;
    }
}