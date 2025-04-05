using System.Collections.Generic;
using DataObjects;
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

    public Recipe GetRandomRecipe()
    {
        return recipes[Random.Range(0, recipes.Count)];
    }
}
