namespace PROG7312_MunicipalServiceApp.DataStructures
{
    // A simple class to hold a key and a value together as a single unit.
    public class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public KeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}