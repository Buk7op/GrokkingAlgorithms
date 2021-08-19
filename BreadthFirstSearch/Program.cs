using System;
using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Valera = new Human("Valera");
            Human Vitya = new Human("Vitya");
            Human Nikita = new Human("Nikita");
            Human Nastya = new Human("Nastya");
            Human Maya = new Human("Maya");
            Vitya.isFriendOf(Valera);
            Vitya.isFriendOf(Nikita);
            Nikita.isFriendOf(Nastya);
            Valera.isFriendOf(Maya);
            Console.WriteLine(BFSearch(Vitya,"Maya"));
            
        }

        static string BFSearch(Human root, string searchingName)
        {
            Queue<Human> humans = new Queue<Human>();
            HashSet<Human> searchedHumans = new HashSet<Human>();
            humans.Enqueue(root);
            searchedHumans.Add(root);
            while (humans.Count > 0)
            {
                Human node = humans.Dequeue();
                if(node.Name == searchingName)  return node.Name;
                foreach(Human friend in node.Friends)
                {
                    if(!searchedHumans.Contains(friend))
                    {
                        humans.Enqueue(friend);
                        searchedHumans.Add(friend);
                    }
                }
            }
            return $"Не найден человек с именем {searchingName}";
        }
    }
}
