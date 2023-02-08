using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Scriptable Objects/Customer", order = 51)]
public class CustomerSO : ScriptableObject
{
    [SerializeField] private FoodSO[] possibleOrders;
    [SerializeField] private Sprite[] appearance;

    public FoodSO Order => possibleOrders[Random.Range(0, possibleOrders.Length)];
    public Sprite CustomerSprite => appearance[Random.Range(0, appearance.Length)];
}
