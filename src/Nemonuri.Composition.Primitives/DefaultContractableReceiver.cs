
using System.Collections;

namespace Nemonuri.Composition;

public class DefaultContractableReceiver<T> : IContractableReceiver<T>
{
    public Type TypeContract => typeof(T);

    public readonly Action<object?, T> _onReceivedCallback;

    public DefaultContractableReceiver(Action<object?, T> onReceivedCallback, object? additionalContract = null, IEqualityComparer? additionalContractEqualityComparer = null)
    {
        Guard.IsNotNull(onReceivedCallback);
        _onReceivedCallback = onReceivedCallback;
        AdditionalContractEqualityComparer = additionalContractEqualityComparer;
        AdditionalContract = additionalContract;
    }

    public IEqualityComparer? AdditionalContractEqualityComparer {get;}

    public object? AdditionalContract {get;}

    public void OnReceived(object? provider, T received) => _onReceivedCallback.Invoke(provider, received);

    void IReceiver.OnReceived(object? provider, object received) => ReceiverPolyfill.PolyfillOnReceived(this, provider, received);
}