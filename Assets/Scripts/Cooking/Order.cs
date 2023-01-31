using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Order : MonoBehaviour
{
    [SerializeField] private FoodSO[] foods;

    private int _orderIndex;

    public FoodType OrderFoodType { get; private set; }

    private void Awake()
    {
        _orderIndex = Random.Range(0, foods.Length);
        OrderFoodType = foods[_orderIndex].FoodType;
        GetComponent<Image>().sprite = foods[_orderIndex].Icon;
    }
}