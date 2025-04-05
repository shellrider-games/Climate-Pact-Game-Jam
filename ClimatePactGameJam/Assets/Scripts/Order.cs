using System;

namespace DefaultNamespace
{
    [Serializable]
    public struct Order
    {
        public string Name { get; set; }
        public float Timer {get; set; }

        public Order(string name, float timer)
        {
            Name = name;
            Timer = timer;
        }
    }
}