using System;

namespace HashTable
{
    //Реализация Хэш таблицы с простой хэш функцией. Хэшфункция здесь это длина ключа. Реализация Хэштаблицы в файле HashTable.cs, реализация элементов в файле Item.cs
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashTable();

            // Добавляем данные в хеш таблицу в виде пар Ключ-Значение.
            hashTable.Insert("Elton John", "Sacriface");
            hashTable.Insert("Eminem", "My name is");
            hashTable.Insert("Rammstein", "Mutter");
            hashTable.Insert("Queen", "We are champions");

            // Выводим хранимые значения на экран.
            ShowHashTable(hashTable);
            

            // Удаляем элемент из хеш таблицы 
            hashTable.Delete("Eminem");
            ShowHashTable(hashTable);
            

            // Получаем хранимое значение из таблицы по ключу.
            string text = hashTable.Search("Rammstein");
            Console.WriteLine(text);
            
        }

        
        private static void ShowHashTable(HashTable hashTable)
        {
            // Проверяем входные аргументы.
            if(hashTable == null)
            {
                throw new ArgumentNullException(nameof(hashTable));
            }
            // Выводим все имеющие пары хеш-значение
            foreach (var item in hashTable.Items)
            {
                // Выводим хеш
                Console.WriteLine(item.Key);

                // Выводим все значения хранимые под этим хешем.
                foreach(var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        
        }
    }
}
