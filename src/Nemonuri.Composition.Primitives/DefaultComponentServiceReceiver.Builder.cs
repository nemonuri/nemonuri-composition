
using System.Collections.Immutable;

namespace Nemonuri.Composition;

public partial class DefaultComponentServiceReceiver
{
    public static Builder CreateBuilder() => new Builder();

    public class Builder
    {
        private readonly ImmutableArray<IContractableReceiver>.Builder _innerArrayBuilder;

        internal Builder()
        {
            _innerArrayBuilder = ImmutableArray.CreateBuilder<IContractableReceiver>();
        }

        public Builder Add(IContractableReceiver contractableReceiver)
        {
            Guard.IsNotNull(contractableReceiver);
            _innerArrayBuilder.Add(contractableReceiver);
            return this;
        }

        public Builder AddIfNotNull(IContractableReceiver? contractableReceiver)
        {
            if (contractableReceiver == null) {return this;}
            _innerArrayBuilder.Add(contractableReceiver);
            return this;
        }

        public DefaultComponentServiceReceiver Build()
        {
            return new DefaultComponentServiceReceiver(_innerArrayBuilder);
        }
    }
}