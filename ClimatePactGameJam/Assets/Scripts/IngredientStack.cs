using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IngredientStack : MonoBehaviour
{
    [SerializeField] private float ingredientGap;
    [SerializeField] private UnityEvent OnIngredientAdded;
    private List<string> ingredientsInStack = new List<string>();
    public List<string> IngredientsInStack => ingredientsInStack;
    
    private RecipeManager recipeManager;
    private GrabGrabbables grabGrabbables;

    private void Awake()
    {
        recipeManager = FindFirstObjectByType<RecipeManager>();
        grabGrabbables = FindFirstObjectByType<GrabGrabbables>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ingredient ingredient))
        {
            List<string> newList = new List<string>(ingredientsInStack);
            newList.Add(ingredient.Name);
            if (recipeManager.PossibleRecipes(newList).Count > 0)
            {
                AddIngredient(ingredient);
            }
        }
    }

    private void AddIngredient(Ingredient ingredient)
    {
        grabGrabbables.TryRelease();
        ingredient.CanBeGrabbed = false;
        if (ingredient.gameObject.TryGetComponent(out Rigidbody rb))
        {
            Destroy(rb);
        }
        ingredientsInStack.Add(ingredient.Name);
        ingredient.transform.SetParent(transform);
        ingredient.transform.localPosition = Vector3.zero + Vector3.up * ingredientsInStack.Count * ingredientGap;
        OnIngredientAdded.Invoke();
        if(ingredient.gameObject.TryGetComponent(out Collider collider))
        {
            collider.enabled = false;
        }
    }
}
