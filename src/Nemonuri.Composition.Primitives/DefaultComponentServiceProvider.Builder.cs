namespace Nemonuri.Composition;
partial class DefaultComponentServiceProvider
{
    public class Builder
    {
        private readonly Dictionary<Type, Lazy<object>> _providerDictionary;

        internal Builder()
        {
            _providerDictionary = new ();
        }

        public Builder Add<TProvider, T>(Func<TProvider> providerFactory)
            where TProvider : IContractableProvider<T>
        {
            Guard.IsNotNull(providerFactory);
            _providerDictionary.Add(typeof(TProvider), new Lazy<object>(providerFactory));
            return this;
        }

        public bool TryAdd<TProvider, T>(Func<TProvider> providerFactory)
            where TProvider : IContractableProvider<T>
        {
            Guard.IsNotNull(providerFactory);
            return _providerDictionary.TryAdd(typeof(TProvider), new Lazy<object>(providerFactory));
        }

        public DefaultComponentServiceProvider Build() =>
            new DefaultComponentServiceProvider(_providerDictionary);

        //TODO: ContainsKey, Keys, Remove, TryRemove, Clear
    }
}