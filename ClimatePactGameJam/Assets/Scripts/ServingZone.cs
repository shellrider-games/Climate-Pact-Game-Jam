using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class ServingZone : MonoBehaviour
    {
        [SerializeField] [Range(0,2)] private int orderID;
        [SerializeField] private UnityEvent<IngredientStack, int> OnTriggerZoneEntered;
        public void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IngredientStack dish))
            {
                OnTriggerZoneEntered.Invoke(dish, orderID);
            }
        }
    }
}