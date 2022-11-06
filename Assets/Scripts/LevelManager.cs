using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    [SerializeField] private Vector2 customerSpawnPosition;
    private GameObject _curCustomer;

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

    public void SpawnCustomer()
    {
        _curCustomer = Instantiate(customer, customerSpawnPosition, Quaternion.identity);
    }
}
