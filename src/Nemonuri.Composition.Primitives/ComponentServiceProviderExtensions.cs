namespace Nemonuri.Composition;

using Primitives;

public static class ComponentServiceProviderExtensions
{
    /// <summary>
    /// Receive Service From IProvider
    /// </summary>
    public static T? ReceiveService<TProvider, T>(this IComponentServiceProvider provider) where TProvider : IProvider<T>
    {
        var p = provider.GetService<TProvider>();
        if (p == null) {return default;};
        return p.Get();
    }

    /// <summary>
    /// Receive First Service From IProvider
    /// </summary>
    public static T? ReceiveService<T>(this IComponentServiceProvider provider, Func<IProvider<T>, T, bool>? predicate = null)
    {
        foreach(IProvider<T> pv in provider.GetProviderSet<T>())
        {
            T t = pv.Get();
            if (predicate?.Invoke(pv, t) ?? true)
            {
                return t;
            }
        }
        return default;
    }
}