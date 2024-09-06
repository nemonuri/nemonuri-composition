namespace Nemonuri.Composition;

public static class ComponentServiceProviderExtensions
{
    /// <summary>
    /// Receive Service From IProvider
    /// </summary>
    public static T? ReceiveService<TProvider, T>(this IComponentServiceProvider provider) where TProvider : IContractableProvider<T>
    {
        Guard.IsNotNull(provider);

        var p = provider.GetService<TProvider>();
        if (p == null) {return default;};
        return p.Get();
    }

    /// <summary>
    /// Receive First Service From IProvider
    /// </summary>
    public static T? ReceiveService<T>(this IComponentServiceProvider provider, Func<IContractableProvider<T>, bool>? predicate)
    {
        Guard.IsNotNull(provider);

        foreach(IContractableProvider<T> pv in provider.GetContractableProviders<T>())
        {
            if (predicate?.Invoke(pv) ?? true)
            {
                return pv.Get();
            }
        }
        return default;
    }

    public static T? ReceiveService<T, TContract>(this IComponentServiceProvider provider, TContract? contract, IEqualityComparer<TContract>? equalityComparer = null)
    {
        Guard.IsNotNull(provider);

        foreach(IContractableProvider<T> pv in provider.GetContractableProviders<T>())
        {
            if (contract == null)
            {
                return pv.Get();
            }

            if (equalityComparer == null)
            {
                if (contract.Equals(pv.Contract))
                {
                    return pv.Get();
                }
                else if (pv.Contract is IEquatable<TContract> equatable && equatable.Equals(contract))
                {
                    return pv.Get();
                }
            }
            else
            {
                if 
                (
                    pv.Contract is TContract vContract &&
                    equalityComparer.Equals(contract, vContract)
                )
                {
                    return pv.Get();
                }
            }
        }

        return default;
    }
}

