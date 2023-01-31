using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Food foodToSpawn;
    private void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            Instantiate(foodToSpawn, transform);
        }
    }
}
