using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    [SerializeField] private new Camera camera;

    private Vector3 _customerSpawnPosition;

    private void Start()
    {
        _customerSpawnPosition = transform.position + new Vector3(camera.pixelWidth, 0);
        SpawnCustomer();
    }

    private void FixedUpdate()
    {
        if (transform.childCount == 0)
        {
            SpawnCustomer();
        }
    }

    private void SpawnCustomer()
    {
        Instantiate(customer, _customerSpawnPosition, Quaternion.identity, transform);
    }
}
