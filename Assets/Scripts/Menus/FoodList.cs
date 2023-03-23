using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodList : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject foodInList;
    [SerializeField] private List<FoodSO> foods;
    void Start()
    {
        foreach (var food in foods)
        {
            var curFood = Instantiate(foodInList, content);
            curFood.GetComponent<FoodInList>().food = food;
        }
    }
}
