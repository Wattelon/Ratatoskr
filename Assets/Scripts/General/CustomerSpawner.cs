using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private List<CustomerSO> possibleCustomers;
    [SerializeField] private GameObject customer;
    [SerializeField] private new Camera camera;

    private Vector3 _customerSpawnPosition;

    private void Start()
    {
        _customerSpawnPosition = transform.position + new Vector3(camera.pixelWidth, 0);
    }

    private void FixedUpdate()
    {
        if (transform.childCount == 0 && possibleCustomers.Count > 0)
        {
            SpawnCustomer();
        }
        else if (possibleCustomers.Count == 0)
        {
            //Прописать конец уровня
        }
    }

    private void SpawnCustomer()
    {
        var customerIndex = Random.Range(0, possibleCustomers.Count);
        var curCustomer = Instantiate(customer, _customerSpawnPosition, Quaternion.identity, transform);
        curCustomer.GetComponent<Customer>().CurCustomer = possibleCustomers[customerIndex];
        possibleCustomers.RemoveAt(customerIndex);
    }
}
