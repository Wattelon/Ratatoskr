using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "Scriptable Objects/Dish", order = 51)]
public class RecipeSO : ScriptableObject
{
    [SerializeField] private FoodSO dishType;
    [SerializeField] private List<FoodType> ingredientsType;

    public FoodSO DishType => dishType;
    public List<FoodType> IngredientsType => ingredientsType;
}