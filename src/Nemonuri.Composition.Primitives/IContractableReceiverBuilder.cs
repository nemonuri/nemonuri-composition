using System.Collections;

namespace Nemonuri.Composition;

public interface IContractableReceiverBuilder<T>
{
    IContractableReceiverBuilder<T> WithOnReceivedCallback(Action<object?, T?>? value);

    IContractableReceiverBuilder<T> WithAdditionalContract(object? value);

    IContractableReceiverBuilder<T> WithAdditionalContractEqualityComparer(IEqualityComparer? value);

    IContractableReceiver<T>? BuildOrNull();
}
