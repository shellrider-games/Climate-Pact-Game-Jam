using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CombinedCollider : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        UpdateCombinedCollider();
    }

    public void UpdateCombinedCollider()
    {
        Bounds combinedBounds = new Bounds();

        bool firstColliderFound = false;
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Collider c))
            {
                c.enabled = true;
                if (!firstColliderFound)
                {
                    combinedBounds = c.bounds;
                    firstColliderFound = true;
                }
                else
                {
                    combinedBounds.Encapsulate(c.bounds);                    
                }
                c.enabled = false;
            }
        }

        if (firstColliderFound)
        {
            boxCollider.center = transform.InverseTransformPoint(combinedBounds.center);
            boxCollider.size = combinedBounds.size;
        }
    }
}
