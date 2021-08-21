using System.Collections.Generic;

namespace BreadthFirstSearch
{
    class Human
    {
        public Human(string name)
        {
            Name = name;
        }
         
        public string Name {  get; set; }
        List<Human> HumanList = new List<Human>();
        public List<Human> Friends 
        {
            get
            {
                return HumanList;
            }
        }
        public void isFriendOf(Human h)
        {
            HumanList.Add(h);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}