using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodInfo : MonoBehaviour
{
    [SerializeField] private List<RecipeSO> recipeList;
    [SerializeField] private List<Namings> namings;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI recipeText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI heatText;
    [SerializeField] private TextMeshProUGUI cutText;

    public void DisplayInfo(FoodSO food)
    {
        icon.color = Color.white;
        icon.sprite = food.Icon;
        name.text = FindName(food.FoodType);

        StringBuilder sb = new StringBuilder();
        recipeText.text = "";
        foreach (var recipe in recipeList)
        {
            if (recipe.DishType == food)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    sb.Append(FindName(ingredient.IngredientType) + ", ");
                }

                if (sb.Length > 1) sb.Remove(sb.Length - 2, 2);
                else sb.Append('?');
                if (recipeText.text == "") recipeText.text = "Рецепт: " + sb;
                else recipeText.text += "\nЕщё рецепт: " + sb;
                sb.Clear();
            }
        }
        
        priceText.text = "Цена в монетах: " + food.Price;
        if (food.HeatTreatable)
        {
            heatText.text = "Можно готовить: да";
            timeText.text = "Время приготовления: " + food.MaxCookingTime + " с";
        }
        else
        {
            heatText.text = "Можно готовить: нет";
            timeText.text = "";
        }
        
        cutText.text = "Можно резать: " + (food.Cutable ? "да" : "нет");
    }

    private string FindName(FoodType food)
    {
        foreach (var naming in namings)
        {
            if (food == naming.Food) return naming.Name;
        }

        return "";
    }
    
    [Serializable]
    private struct Namings
    {
        public FoodType Food;
        public string Name;
    }
}
