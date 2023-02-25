using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food foodPrefab;
    [SerializeField] private FoodSO foodTypeToSpawn;
    [SerializeField] private Gold goldCounter;

    public FoodSO FoodTypeToSpawn => foodTypeToSpawn;

    private void Start()
    {
        Instantiate(foodPrefab, transform);
    }

    private void FixedUpdate()
    {
        if (!transform.GetComponentInChildren(typeof(Food)))
        {
            Instantiate(foodPrefab, transform);
            goldCounter.IncreaseExpenses(foodTypeToSpawn.Price);
        }
    }
}
