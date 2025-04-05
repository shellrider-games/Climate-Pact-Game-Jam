using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabGrabbables : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 0.1f;
    [SerializeField] private LayerMask hoverableLayerMask;
    private GameObject grabbedObject;

    public void OnMainInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            TryGrab();
        }

        if (context.canceled)
        {
            TryRelease();
        }
    }

    public void Grab(GameObject go)
    {
        grabbedObject = go;
    }

    private void TryGrab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Grabbable"))
            {
                grabbedObject = hit.collider.gameObject;
            }
        }
    }

    public void TryRelease()
    {
        grabbedObject = null;
    } 

    private void MoveGrabbedObject()
    {
        if (grabbedObject == null) {return;}
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hoverableLayerMask))
        {
            grabbedObject.transform.position = hit.point + Vector3.up * hoverHeight;
        }
    }
    
    public void Update()
    {
        MoveGrabbedObject();
    }
}
