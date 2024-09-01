using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Nemonuri.Composition.Primitives;

public class ProviderSetDictionary: IReadOnlyProviderSetDictionary, IDictionary<Type, IEnumerable<object>>
{
    private readonly Dictionary<Type, IEnumerable<object>?> _dictionary;

    public ProviderSetDictionary()
    {
        _dictionary = new();
    }

    public void Add(Type key, IEnumerable<object> value)
    {
         _dictionary.Add(key, value);
    }

    public bool ContainsKey(Type key)
    {
        return  _dictionary.ContainsKey(key);
    }

    public bool Remove(Type key)
    {
        return  _dictionary.Remove(key);
    }

    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out IEnumerable<object> value)
    {
        return  _dictionary.TryGetValue(key, out value);
    }

    public IEnumerable<object> this[Type key] { get =>  _dictionary[key]; set =>  _dictionary[key] = value; }

    public ICollection<Type> Keys =>  _dictionary.Keys;

    public ICollection<IEnumerable<object>> Values =>  _dictionary.Values;

    void ICollection<KeyValuePair<Type, IEnumerable<object>>>.Add(KeyValuePair<Type, IEnumerable<object>> item)
    {
        ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).Add(item);
    }

    void ICollection<KeyValuePair<Type, IEnumerable<object>>>.Clear()
    {
        ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).Clear();
    }

    bool ICollection<KeyValuePair<Type, IEnumerable<object>>>.Contains(KeyValuePair<Type, IEnumerable<object>> item)
    {
        return ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).Contains(item);
    }

    void ICollection<KeyValuePair<Type, IEnumerable<object>>>.CopyTo(KeyValuePair<Type, IEnumerable<object>>[] array, int arrayIndex)
    {
        ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).CopyTo(array, arrayIndex);
    }

    bool ICollection<KeyValuePair<Type, IEnumerable<object>>>.Remove(KeyValuePair<Type, IEnumerable<object>> item)
    {
        return ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).Remove(item);
    }

    public int Count => _dictionary.Count;

    bool ICollection<KeyValuePair<Type, IEnumerable<object>>>.IsReadOnly => ((ICollection<KeyValuePair<Type, IEnumerable<object>>>)_dictionary).IsReadOnly;

    public IEnumerator<KeyValuePair<Type, IEnumerable<object>>> GetEnumerator() => _dictionary.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_dictionary).GetEnumerator();
    }

    IEnumerable<Type> IReadOnlyDictionary<Type, IEnumerable<object>>.Keys => Keys;

    IEnumerable<IEnumerable<object>> IReadOnlyDictionary<Type, IEnumerable<object>>.Values => Values;
}