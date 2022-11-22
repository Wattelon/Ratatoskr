using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    [SerializeField] private Vector2 customerSpawnPosition;

    void Start()
    {
        SpawnCustomer();
    }

    private void FixedUpdate()
    {
        if (!FindObjectOfType<Customer>())
        {
            SpawnCustomer();
        }
    }

    private void SpawnCustomer()
    {
        Instantiate(customer, customerSpawnPosition, Quaternion.identity);
    }
}
