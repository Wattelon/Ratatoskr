using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishMaking : MonoBehaviour
{
    [SerializeField] private RecipeSO[] availableRecipes;
    [SerializeField] private RecipeSO suitableRecipe;
    
    public FoodSO DishType { get; private set; }
    public Processing FoodProcessing { get; private set; }
    
    private List<FoodType> _ingredients = new List<FoodType>();
    private List<Processing> _processings = new List<Processing>();
    private Transform _parent;
    private int _ingredientsAmount;

    private void Start()
    {
        _parent = transform.parent;
        _ingredientsAmount = _parent.childCount - 2;
        for (int i = 0; i < _ingredientsAmount; i++)
        {
            Transform ingredient = _parent.GetChild(0);
            _ingredients.Add(ingredient.GetComponent<Food>().FoodType);
            _processings.Add(ingredient.GetComponent<Food>().FoodProcessing);
            ingredient.SetParent(transform);
            ingredient.gameObject.SetActive(false);
        }
        IdentifyRecipe(_ingredients);
        DishType = suitableRecipe.DishType;
        SetProcessingLevel(_processings);
        gameObject.GetComponent<Food>().enabled = true;
    }

    private void IdentifyRecipe(List<FoodType> ingredients)
    {
        foreach (var recipe in availableRecipes)
        {
            bool isRightRecipe = true;
            if (recipe.IngredientsType.Distinct().Count() != ingredients.Distinct().Count())
            {
                continue;
            }
            foreach (var ingredient in ingredients.Distinct())
            {
                if (recipe.IngredientsType.Count(x => x == ingredient) != ingredients.Count(x => x == ingredient))
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

    private void SetProcessingLevel(List<Processing> processing)
    {
        if (processing.Contains(Processing.Burned))
        {
            FoodProcessing = Processing.Burned;
        }
        else if (processing.Contains(Processing.Raw))
        {
            FoodProcessing = Processing.Raw;
        }
        else if (processing.Contains(Processing.Cooked))
        {
            FoodProcessing = Processing.Cooked;
        }
        else
        {
            FoodProcessing = Processing.Perfect;
        }
    }
}