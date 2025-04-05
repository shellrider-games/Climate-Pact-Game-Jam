using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    public GameObject SpawnObject()
    {
        var noob = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        return noob;
    }
}
