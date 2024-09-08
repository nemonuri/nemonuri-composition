namespace Nemonuri.Composition.Infrastructure;

public static class ComponentServiceReceiverExtensions
{
    public static void Import(this IComponentServiceReceiver receiver, IComponentServiceProvider provider)
    {
        Guard.IsNotNull(receiver);
        Guard.IsNotNull(provider);

        foreach (var cr in receiver.ContractableReceivers)
        {
            foreach (var cp in provider.GetContractableProvidersByTypeContract(cr.TypeContract))
            {
                if (cr.TryReceive(cp))
                {
                    break;
                }
            }
        }
    }

    public static void ImportIfBooleanSwitchFalse(this IComponentServiceReceiver receiver, IComponentServiceProvider provider, ref bool booleanSwitch)
    {
        if (booleanSwitch)
        {
            booleanSwitch = true;
            receiver.Import(provider);
        }
    }
}