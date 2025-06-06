using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GrabGrabbables : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 0.1f;
    [SerializeField] private LayerMask hoverableLayerMask;
    private GameObject grabbedObject;
    [SerializeField]
    public UnityEvent grabSuccesfull = new UnityEvent();
    [SerializeField]
    public UnityEvent grabReleased = new UnityEvent();

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
            if (hit.collider.gameObject.CompareTag("Grabbable") || hit.collider.gameObject.CompareTag("Ingredient"))
            {
                if (hit.collider.gameObject.CompareTag("Ingredient"))
                {
                    if (hit.collider.gameObject.TryGetComponent(out Ingredient ingredient) && !ingredient.CanBeGrabbed)
                    {
                        return;
                    }
                }
                grabbedObject = hit.collider.gameObject;
                grabSuccesfull.Invoke();
            }
        }
    }

    public void TryRelease()
    {
        if (grabbedObject != null)
        {
            grabReleased.Invoke();
        }
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
