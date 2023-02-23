using System;
using System.Collections.Generic;
using UnityEngine;

public class DishMaking : MonoBehaviour
{
    [SerializeField] private RecipeSO[] availableRecipes;
    [SerializeField] private RecipeSO suitableRecipe;
    
    public FoodSO DishType { get; private set; }
    public HeatTreating FoodHeatTreating { get; private set; }
    
    private List<Ingredient> _ingredients = new List<Ingredient>();
    private List<HeatTreating> _processing = new List<HeatTreating>();
    private Transform _parent;
    private Ingredient _ingredient;
    private int _ingredientsAmount;

    private void Start()
    {
        _parent = transform.parent;
        _ingredientsAmount = _parent.childCount - 2;
        for (int i = 0; i < _ingredientsAmount; i++)
        {
            Transform ingredientTransform = _parent.GetChild(0);
            Food food = ingredientTransform.GetComponent<Food>();
            _ingredients.Add(new Ingredient(food.FoodType, Convert.ToBoolean(food.FoodHeatTreating), food.IsCut));
            _processing.Add(food.FoodHeatTreating);
            ingredientTransform.SetParent(transform);
            ingredientTransform.gameObject.SetActive(false);
        }
        IdentifyRecipe(_ingredients);
        DishType = suitableRecipe.DishType;
        SetProcessingLevel(_processing);
        gameObject.GetComponent<Food>().enabled = true;
    }

    private void IdentifyRecipe(List<Ingredient> ingredients)
    {
        List<Ingredient> neededIngredients = new List<Ingredient>();
        foreach (var recipe in availableRecipes)
        {
            bool isRightRecipe = true;
            neededIngredients.Clear();
            neededIngredients.AddRange(recipe.Ingredients);
            foreach (var ingredient in ingredients)
            {
                if (neededIngredients.Contains(ingredient))
                {
                    neededIngredients.Remove(ingredient);
                }
                else
                {
                    isRightRecipe = false;
                    break;
                }
            }

            if (isRightRecipe)
            {
                suitableRecipe = recipe;
                break;
            }
        }
    }

    private void SetProcessingLevel(List<HeatTreating> processing)
    {
        if (processing.Contains(HeatTreating.Burned))
        {
            FoodHeatTreating = HeatTreating.Burned;
        }
        else if (processing.Contains(HeatTreating.Cooked))
        {
            FoodHeatTreating = HeatTreating.Cooked;
        }
        else
        {
            FoodHeatTreating = HeatTreating.Perfect;
        }
    }
}