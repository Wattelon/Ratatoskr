using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DishMaking : MonoBehaviour
{
    [SerializeField] private RecipeSO[] availableRecipes;
    [SerializeField] private RecipeSO suitableRecipe;
    
    public FoodSO DishType { get; private set; }
    public HeatTreating FoodHeatTreating { get; private set; }
    
    private List<FoodType> _ingredientsType = new List<FoodType>();
    private List<HeatTreating> _heatTreatings = new List<HeatTreating>();
    private List<CutTreating> _cutTreatings = new List<CutTreating>();
    private List<Ingredient> _ingredients = new List<Ingredient>();
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
            var food = ingredientTransform.GetComponent<Food>();
            _ingredientsType.Add(food.FoodType);
            _heatTreatings.Add(food.FoodHeatTreating);
            _cutTreatings.Add(food.FoodCutTreating);
                    _ingredient.ingredientType = food.FoodType;
                    _ingredient.heatProcessing = food.FoodHeatTreating;
                    _ingredient.cutProcessing = food.FoodCutTreating;
                    _ingredients.Add(_ingredient);
            ingredientTransform.SetParent(transform);
            ingredientTransform.gameObject.SetActive(false);
        }
        IdentifyRecipe(_ingredientsType);
        DishType = suitableRecipe.DishType;
        SetProcessingLevel(_heatTreatings);
        gameObject.GetComponent<Food>().enabled = true;
    }

    private void IdentifyRecipe(List<FoodType> ingredients)
    {
        foreach (var recipe in availableRecipes)
        {
            bool isRightRecipe = true;
            if (recipe.Ingredients.Distinct().Count() != ingredients.Distinct().Count())
            {
                continue;
            }
            foreach (var ingredient in ingredients.Distinct())
            {
                if (recipe.Ingredients.Count(x => x.ingredientType == ingredient) != ingredients.Count(x => x == ingredient))
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
        else if (processing.Contains(HeatTreating.Raw))
        {
            FoodHeatTreating = HeatTreating.Raw;
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