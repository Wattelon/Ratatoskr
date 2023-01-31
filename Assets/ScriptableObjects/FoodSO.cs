using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Scriptable Objects/Food", order = 51)]
public class FoodSO : ScriptableObject
{
    [SerializeField] private FoodType foodType;
    [SerializeField] private Sprite icon;
    [Range(1, 99)]
    [SerializeField] private int price;
    [Range(1, 99)]
    [SerializeField] private float maxCookingTime;
    [SerializeField] private bool heatTreatable;

    public FoodType FoodType => foodType;
    public Sprite Icon => icon;
    public int Price => price;
    public float MaxCookingTime => maxCookingTime;
    public bool HeatTreatable => heatTreatable;
}