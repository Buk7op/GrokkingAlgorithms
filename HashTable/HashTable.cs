using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    class HashTable
    {
        // Максимальное длина ключа и capacity HashTable.
        private readonly byte maxSize = 255;
        // Словарь - хранилище пар хэш-список элементов.
        private Dictionary<int, List<Item>> items = null;
        // Коллекция хранимых данных, пригодится при выводе хранящихся в хэштаблице элементов на экран.
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>> Items => items?.ToList()?.AsReadOnly();

        public HashTable()
        {
            items = new Dictionary<int, List<Item>>(maxSize);
        }

        public void Insert(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > maxSize)
            {
                throw new ArgumentException($"Превышено максимально число символов: {maxSize}", nameof(key));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Item item = new Item(key,value);
            int hash = GetHash(key);
            List<Item> hashTableItem = null;
            if (items.ContainsKey(hash))
            {
                hashTableItem = items[hash];
                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);
                if (oldElementWithKey != null)
                {
                    throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}.", nameof(key));
                }
                items[hash].Add(item);
            }
            else
            {
                hashTableItem = new List<Item>{ item };
                items.Add(hash, hashTableItem);
            }
        }
        public void Delete(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {maxSize} символов.", nameof(key));
            }
            var hash = GetHash(key);
            if (!items.ContainsKey(hash))
            {
                return;
            }
            var hashTableItem = items[hash];
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);
            if (item != null)
            {
                hashTableItem.Remove(item);
            }
        }

        public string Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length > maxSize)
            {
                throw new ArgumentException($"Максимальная длинна ключа составляет {maxSize} символов.", nameof(key));
            }

            var hash = GetHash(key);

            if(!items.ContainsKey(hash))
            {
                return null;
            }

            var hashTableItem = items[hash];

            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                if (item != null)
                {
                   return item.Value;
                }
            }

            return null;
        }

        private int GetHash(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if(key.Length > maxSize)
            {
                throw new ArgumentException($"Превышено максимально число символов: {maxSize}", nameof(key));
            }
            int hash = key.Length;
            return hash;
        }
    }
}