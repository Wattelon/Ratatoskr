using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private LevelsSO levels;
    [SerializeField] private GameObject customer;
    [SerializeField] private new Camera camera;
    [SerializeField] private LevelEnd levelEnd;

    private List<CustomerSO> _possibleCustomers = new List<CustomerSO>();
    private Vector3 _customerSpawnPosition;
    private int _levelID;

    private void Start()
    {
        _customerSpawnPosition = transform.position + new Vector3(camera.pixelWidth, 0);
        _levelID = LevelTracker.LevelID;
        _possibleCustomers.AddRange(levels.Levels[_levelID].CustomersSO);
    }

    private void FixedUpdate()
    {
        if (transform.childCount == 0 && _possibleCustomers.Count > 0)
        {
            SpawnCustomer();
        }
        else if (transform.childCount == 0 && _possibleCustomers.Count == 0)
        {
            levelEnd.EndLevel();
        }
    }

    private void SpawnCustomer()
    {
        var customerIndex = Random.Range(0, _possibleCustomers.Count);
        var curCustomer = Instantiate(customer, _customerSpawnPosition, Quaternion.identity, transform);
        curCustomer.GetComponent<Customer>().CurCustomer = _possibleCustomers[customerIndex];
        _possibleCustomers.RemoveAt(customerIndex);
    }
}
