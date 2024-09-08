namespace Nemonuri.Composition.Infrastructure;

public static class ContractableReceiverExtensions
{
    public static bool ContractMatches
    (
        this IContractableReceiver receiver,
        IContractableProvider provider
    )
    {
        Guard.IsNotNull(receiver);
        Guard.IsNotNull(provider);

        return ContractOperation.ContractMatches(receiver, provider, receiver.AdditionalContractEqualityComparer);
    }

    public static bool TryReceive
    (
        this IContractableReceiver receiver,
        IContractableProvider provider
    )
    {
        if (receiver.ContractMatches(provider))
        {
            receiver.OnReceived(provider, provider.Get());
            return true;
        }
        else
        {
            return false;
        }
    }
}