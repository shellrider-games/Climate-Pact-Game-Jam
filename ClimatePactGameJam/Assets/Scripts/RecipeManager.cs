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
        foreach (var recipe in recipes)
        {
            Debug.Log(recipe);
        }
    }
    
}
