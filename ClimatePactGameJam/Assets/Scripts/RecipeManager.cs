using System.Collections.Generic;
using System.Linq;
using DataObjects;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    [SerializeField] private TextAsset recipesData;
    private List<Recipe> recipes;

    private void Awake()
    {
        recipes = JsonConvert.DeserializeObject<List<Recipe>>(recipesData.text);
    }
    
    public List<Recipe> PossibleRecipes(List<string> ingredientStack)
    {
        List<Recipe> possibleRecipes = new List<Recipe>();
        foreach (Recipe recipe in recipes)
        {
            if (recipe.Stack.Count < ingredientStack.Count) {continue;}
            bool startEqual = true;
            for (int i = 0; i < ingredientStack.Count; i++)
            {
                if (ingredientStack[i] != recipe.Stack[i])
                {
                    startEqual = false;
                }
            }
            if (startEqual){ possibleRecipes.Add(recipe); }
        }
        return possibleRecipes;
    }

    [CanBeNull]
    public Recipe CheckCompleteRecipe(List<string> ingredientStack)
    {
        foreach (var recipe in recipes)
        {
            if (recipe.Stack.SequenceEqual(ingredientStack))
            {
                return recipe;
            }
        }
        return null;
    }

    public Recipe GetRandomRecipe()
    {
        return recipes[Random.Range(0, recipes.Count)];
    }

    public bool CheckRecipe(List<string> ingredientStack, string recipeName)
    {
        Recipe recipe = CheckCompleteRecipe(ingredientStack);
        if (recipe == null) { return false; }
        return recipe.Name == recipeName;
    }
}
