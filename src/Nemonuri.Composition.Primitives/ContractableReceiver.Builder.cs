using System.Collections;

namespace Nemonuri.Composition;

public partial class ContractableReceiver<T>
{
    public class Builder : IContractableReceiverBuilder<T>
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


        public ContractableReceiver<T>? BuildOrNull()
        {
            if (OnReceivedCallback == null)
            {
                return null;
            }
            else
            {
                return new ContractableReceiver<T>
                    (
                        OnReceivedCallback,
                        AdditionalContract,
                        AdditionalContractEqualityComparer
                    );
            }
        }

        IContractableReceiverBuilder<T> IContractableReceiverBuilder<T>.WithOnReceivedCallback(Action<object?, T?>? value) =>
            WithOnReceivedCallback(value);

        IContractableReceiverBuilder<T> IContractableReceiverBuilder<T>.WithAdditionalContract(object? value) =>
            WithAdditionalContract(value);

        IContractableReceiverBuilder<T> IContractableReceiverBuilder<T>.WithAdditionalContractEqualityComparer(IEqualityComparer? value) =>
            WithAdditionalContractEqualityComparer(value);

        IContractableReceiver<T>? IContractableReceiverBuilder<T>.BuildOrNull() =>
            BuildOrNull();
    }
}