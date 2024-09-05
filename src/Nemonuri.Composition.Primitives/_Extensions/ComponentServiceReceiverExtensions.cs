namespace Nemonuri.Composition;

public static class ComponentServiceReceiverExtensions
{
    public static T? FindService<T, TContract>
    (
        this IComponentServiceReceiver<T, TContract> receiver,
        IComponentServiceProvider provider
    )
    {
        Guard.IsNotNull(receiver);
        Guard.IsNotNull(provider);

        return provider.ReceiveService<T, TContract>(receiver.Contract, receiver.ContractEqualityComparer);
    }
}