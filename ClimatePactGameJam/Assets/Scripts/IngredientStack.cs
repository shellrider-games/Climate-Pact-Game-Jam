using System;
using DataObjects;
using UnityEngine;

public class IngredientStack : MonoBehaviour
{
    [SerializeField] private RecipeManager recipeManager;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Assert(recipeManager != null, "recipeManger is not allowed to be null");
        if (other.gameObject.TryGetComponent(out Ingredient stackable))
        {
            
        }
    }
}
