using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GrabGrabbables))]
public class InteractWithSpawner : MonoBehaviour
{
    private GrabGrabbables grabGrabbables;

    private void Awake()
    {
        grabGrabbables = GetComponent<GrabGrabbables>();
    }

    private void TrySpawn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("ClickSpawner"))
            {
                ClickSpawner spawner = hit.collider.gameObject.GetComponent<ClickSpawner>();
                var spawnedObject = spawner.SpawnObject();
                grabGrabbables.Grab(spawnedObject);
            }
        }
    }

    public void OnMainInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TrySpawn();
        }
    }
}
