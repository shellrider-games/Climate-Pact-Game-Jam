using UnityEngine;

public class CompostFood : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Grabbable")
            {
                Destroy(collision.gameObject);
            }
        }
}
