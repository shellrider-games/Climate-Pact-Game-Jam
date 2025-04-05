using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField][Range(0,120f)] private float timeToCompleteOrder = 30f;
    [SerializeField][Range(0,120f)] private float timeBetweenOrders = 30f;
    [SerializeField][Range(0,10f)] private float timeBetweenOrdersVariance = 7f;
    
    [SerializeField] private RecipeManager recipeManager;
    private List<Order> activeOrders;

    private void AddOrder(Order order)
    {
        activeOrders.Add(order);
    }
    private void Start()
    {
        activeOrders = new List<Order>();
        AddOrder(new Order());
    }

    private Order GenerateOrder()
    {
        string dishName = recipeManager.GetRandomRecipe().Name;
        return new Order(dishName, timeToCompleteOrder);
    }
}
