using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Scriptable Objects/Recipe", order = 51)]
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
    public FoodType IngredientType;
    public bool IsCooked;
    public bool IsCut;

    public Ingredient(FoodType ingredientType, bool isCooked, bool isCut)
    {
        IngredientType = ingredientType;
        IsCooked = isCooked;
        IsCut = isCut;
    }
}