using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dish", menuName = "Scriptable Objects/Dish", order = 51)]
public class RecipeSO : ScriptableObject
{
    [SerializeField] private FoodSO dishType;
    [SerializeField] private List<Ingredient> ingredients;

    public FoodSO DishType => dishType;
    public List<Ingredient> Ingredients => ingredients;
}

[Serializable]
public struct Ingredient
{
    public FoodType ingredientType;
    public HeatTreating heatProcessing;
    public CutTreating cutProcessing;
}