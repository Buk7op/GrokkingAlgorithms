using System;

namespace HashTable
{
    class Item
    {
        public string Key { get; private set; }
        public string Value { get; set; }
        public Item(string key, string value)
        {
            if(string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));
            if(string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return Key;
        }
    }
}