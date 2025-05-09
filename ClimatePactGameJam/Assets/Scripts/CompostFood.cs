using UnityEngine;
using UnityEngine.Events;

public class CompostFood : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _unityEvent = new UnityEvent();
    
    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Grabbable" || collision.gameObject.tag == "Ingredient")
            {
                Destroy(collision.gameObject);
                _unityEvent.Invoke();
            }
        }
}
