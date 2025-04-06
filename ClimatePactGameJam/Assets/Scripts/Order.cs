using System;

namespace DefaultNamespace
{
    [Serializable]
    public struct Order
    {
        public string Name { get; set; }
        public float TotalTime {get; set;}
        public float Timer {get; set; }
        public bool Active {get; set; }       
        
        public Order(string name, float timer)
        {
            Name = name;
            TotalTime = timer;
            Timer = timer;
            Active = false;
        }
    }
}