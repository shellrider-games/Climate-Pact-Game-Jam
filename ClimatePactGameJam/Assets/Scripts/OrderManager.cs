using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class OrderManager : MonoBehaviour
{
    [SerializeField][Range(0,120f)] private float timeToCompleteOrder = 30f;
    [SerializeField][Range(0,120f)] private float timeBetweenOrders = 30f;
    [SerializeField][Range(0,10f)] private float timeBetweenOrdersVariance = 7f;
    
    [SerializeField][Range(0, 50)] private int orderBasePrice = 10;
    [SerializeField][Range(0, 50)] private int orderMaximumTip = 5;
    
    [SerializeField] private MoneyManager moneyManager;
    [SerializeField] private RecipeManager recipeManager;
    [SerializeField] private OrderDisplay[] orderDisplays;
    [SerializeField] private ImageRepository imageRepository;
    
    [Header("Events")]
    [SerializeField] private UnityEvent onOrderComplete; 
    
    private Order[] orders;
    private float nextOrderTimer;
    

    private void Update()
    {
        for (int i = 0; i < orders.Length; i++)
        {
            if(!orders[i].Active) {continue;}
            orders[i].Timer = Mathf.Max(orders[i].Timer - Time.deltaTime, 0);
            if (orders[i].Timer <= 0) { orders[i].Active = false; }
        }
        nextOrderTimer -= Time.deltaTime;
        if (nextOrderTimer <= 0)
        {
            TryAddOrder(GenerateOrder());
            nextOrderTimer = CalculateTimeTillNextOrder();
        }
        UpdateOrderDisplays();
    }

    private float CalculateTimeTillNextOrder()
    {
        return timeBetweenOrders + Random.Range(-timeBetweenOrdersVariance * .5f, timeBetweenOrdersVariance * .5f);
    }
    
    private void UpdateOrderDisplays()
    {
        for (int i = 0; i < orderDisplays.Length; i++)
        {
            orderDisplays[i].gameObject.SetActive(orders[i].Active);
            orderDisplays[i].UpdateTimer(orders[i].Timer, orders[i].TotalTime);
        }
    }
    
    private void TryAddOrder(Order order)
    {
        if (orders.All(o => o.Active))
        {
            Debug.Log("Tried to add order but no more space");
            return;
        }
        for (int i = 0; i < orders.Length; i++)
        {
            if (orders[i].Active) { continue;}
            orders[i] = order;
            orders[i].Active = true;
            orderDisplays[i].UpdateOrderText(orders[i].Name);
            orderDisplays[i].UpdateOrderImage(imageRepository.ImageDictionary[orders[i].Name]);
            break;
        }
    }
    
    private void Start()
    {
        orders = new Order[orderDisplays.Length];
        TryAddOrder(GenerateOrder());
        nextOrderTimer = CalculateTimeTillNextOrder();
        UpdateOrderDisplays();
    }

    private Order GenerateOrder()
    {
        string dishName = recipeManager.GetRandomRecipe().Name;
        return new Order(dishName, timeToCompleteOrder);
    }

    public void TryCompleteOrder(IngredientStack dish, int id)
    {
        if(!orders[id].Active){ return; }
        if (recipeManager.CheckRecipe(dish.IngredientsInStack, orders[id].Name))
        {
            Destroy(dish.gameObject);
            orders[id].Active = false;
            UpdateOrderDisplays();
            onOrderComplete.Invoke();
            moneyManager.GainMoney(
                orderBasePrice + 
                        Mathf.FloorToInt(orders[id].Timer / orders[id].TotalTime * orderMaximumTip)
                );
            if (orders.Count(o => o.Active) == 0)
            {
                TryAddOrder(GenerateOrder());
            }
        }
    }
}
