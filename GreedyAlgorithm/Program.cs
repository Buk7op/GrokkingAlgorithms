using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, List<String>> stations = new Dictionary<String, List<String>>();
            List<string> statesNeeded = new List<string> { "mt", "wa", "or", "id", "nv", "ut", "са", "az" };
            stations["kone"] = new List<string> { "id", "nv", "ut" };
            stations["ktwo"] = new List<string> {"wa", "id", "mt"};
            stations["kthree"] = new List<string> {"or", "nv", "са"};
            stations["kfour"] = new List<string> {"nv", "ut"}; 
            stations["kfive"] =  new List<string> {"ca", "az"};
            HashSet<string> neededStations = new HashSet<string>();
            while(statesNeeded.Count != 0)
            {
                int intersectionsCount = default;
                string bestIntersect = default;
                //Сначала находим станцию которая покрывает большее количество непокрытых станций
                foreach(string key in stations.Keys)
                {
                    if(stations[key].Intersect(statesNeeded).Count() > intersectionsCount)
                    {
                        intersectionsCount = stations[key].Intersect(statesNeeded).Count();
                        bestIntersect = key;
                    }
                }
                //Затем "покрываем штаты" удаляем их из списка непокрытых штатов
                foreach(string st in stations[bestIntersect])
                {
                    statesNeeded.Remove(st);
                }
                //Добавляем станцию в конечный список нужных станций
                neededStations.Add(bestIntersect);
                //Удаляем станцию из первоначального списка
                stations.Remove(bestIntersect);

            }
            foreach(string st in neededStations)
            {
                Console.WriteLine(st);
            }
        }
    }
}
