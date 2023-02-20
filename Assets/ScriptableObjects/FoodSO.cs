using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Scriptable Objects/Food", order = 51)]
public class FoodSO : ScriptableObject
{
    [SerializeField] private FoodType foodType;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite iconCut;
    [Range(1, 99)]
    [SerializeField] private int price;
    [Range(0, 99)]
    [SerializeField] private int neededCuts;
    [Range(0, 99)]
    [SerializeField] private float maxCookingTime;
    [SerializeField] private bool heatTreatable;
    [SerializeField] private bool cutable;

    public FoodType FoodType => foodType;
    public Sprite Icon => icon;
    public Sprite IconCut => iconCut;
    public int Price => price;
    public int NeededCuts => neededCuts;
    public float MaxCookingTime => maxCookingTime;
    public bool HeatTreatable => heatTreatable;
    public bool Cutable => cutable;
}