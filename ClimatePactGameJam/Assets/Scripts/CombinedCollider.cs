using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CombinedCollider : MonoBehaviour
{
    private BoxCollider collider;

    private void Awake()
    {
        collider = GetComponent<BoxCollider>();
        UpdateCombinedCollider();
    }

    public void UpdateCombinedCollider()
    {
        Bounds combinedBounds = new Bounds();

        bool firstColliderFound = false;
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Collider c) && c.enabled)
            {
                if (!firstColliderFound)
                {
                    combinedBounds = c.bounds;
                }
                firstColliderFound = true;
                combinedBounds.Encapsulate(c.bounds);
            }
        }

        if (firstColliderFound)
        {
            collider.center = transform.InverseTransformPoint(combinedBounds.center);
            collider.size = combinedBounds.size;
        }
    }
}
