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

        internal Builder(Dictionary<Type, Lazy<object>> providerDictionary)
        {
            Guard.IsNotNull(providerDictionary);
            lock (providerDictionary)
            {
                _providerDictionary = new Dictionary<Type, Lazy<object>>(providerDictionary);   // Do swallow copy to '_providerDictionary'
            }
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

        //TODO: Remove, TryRemove, Clear

        public bool ContainsKey(Type type)
        {
            Guard.IsNotNull(type);
            return _providerDictionary.ContainsKey(type);
        }

        public int Count => _providerDictionary.Count;

        public ICollection<Type> Keys => _providerDictionary.Keys;

        public DefaultComponentServiceProvider Build() =>
            new DefaultComponentServiceProvider(_providerDictionary);
    }
}