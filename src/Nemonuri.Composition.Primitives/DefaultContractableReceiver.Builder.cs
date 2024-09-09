using System.Collections;

namespace Nemonuri.Composition;

public partial class DefaultContractableReceiver<T>
{
    public class Builder
    {
        public Builder() {}
        
        public Action<object?, T?>? OnReceivedCallback {get;set;}
        
        public object? AdditionalContract {get;set;}

        public IEqualityComparer? AdditionalContractEqualityComparer {get;set;}


        public Builder WithOnReceivedCallback(Action<object?, T?>? value)
        {
            OnReceivedCallback = value;
            return this;
        }

        public Builder WithAdditionalContract(object? value)
        {
            AdditionalContract = value;
            return this;
        }

        public Builder WithAdditionalContractEqualityComparer(IEqualityComparer? value)
        {
            AdditionalContractEqualityComparer = value;
            return this;
        }


        public DefaultContractableReceiver<T>? BuildOrNull()
        {
            if (OnReceivedCallback == null)
            {
                return null;
            }
            else
            {
                return new DefaultContractableReceiver<T>
                    (
                        OnReceivedCallback,
                        AdditionalContract,
                        AdditionalContractEqualityComparer
                    );
            }
        }
    }
}