using System.Collections;

namespace Nemonuri.Composition.Infrastructure;

public static class ContractOperation
{
    public static bool ContractMatches(IContract required, IContract received, IEqualityComparer? contractEqualityComparer)
    {
        Guard.IsNotNull(required);
        Guard.IsNotNull(received);

        return
            TypeContractMatches(required.Type, received.Type) &&
            AdditionalContractMatches(required.AdditionalContract, received.AdditionalContract, contractEqualityComparer);
    }

    public static bool TypeContractMatches(Type? required, Type? received)
    {
        if (required == null || received == null) {return false;}
        return required == received;
    }

    public static bool AdditionalContractMatches(object? required, object? received, IEqualityComparer? contractEqualityComparer)
    {
        if (required == null) {return true;}

        if (received == null) {return false;}

        if (contractEqualityComparer == null)
        {
            return received.Equals(required);
        }
        else
        {
            return contractEqualityComparer.Equals(required, received);
        }
    }
}