using System;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    private FoodSO food;
    private Image _image;
    
    public FoodType OrderFoodType { get; private set; }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        Customer customer = transform.parent.parent.GetComponent<Customer>();
        food = customer.CurOrder;
        if (customer.IsOrderCut)
        {
            _image.sprite = food.IconCut;
        }
        else
        {
            _image.sprite = food.Icon;
        }

        if (food.HeatTreatable && !customer.IsOrderCooked)
        {
            _image.color = Color.white;
        }
        OrderFoodType = food.FoodType;
    }
}