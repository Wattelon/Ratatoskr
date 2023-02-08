using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food foodPrefab;
    [SerializeField] private FoodSO foodTypeToSpawn;

    public FoodSO FoodTypeToSpawn => foodTypeToSpawn;
    
    private void FixedUpdate()
    {
        if (!transform.GetComponentInChildren(typeof(Food)))
        {
            Instantiate(foodPrefab, transform);
        }
    }
}
