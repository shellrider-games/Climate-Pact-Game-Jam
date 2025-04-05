using System;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string Name;
    public bool CanBeGrabbed;

    private void Awake()
    {
        CanBeGrabbed = true;
    }
}
