using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    private FoodSO food;
    
    public FoodType OrderFoodType { get; private set; }

    private void Start()
    {
        food = transform.parent.parent.GetComponent<Customer>().CurOrder;
        OrderFoodType = food.FoodType;
        GetComponent<Image>().sprite = food.Icon;
    }
}