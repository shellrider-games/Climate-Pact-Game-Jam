using System.Collections.Generic;

namespace DataObjects
{
    [System.Serializable]
    public class Recipe
    {
        public string Name { get; set; }
        public List<string> Stack { get; set; }

        public override string ToString()
        {
            return $"Recipe: {Name}";
        }
    }
}