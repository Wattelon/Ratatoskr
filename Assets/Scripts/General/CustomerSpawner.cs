using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private LevelsSO levels;
    [SerializeField] private GameObject customer;
    [SerializeField] private new Camera camera;
    [SerializeField] private GameObject endingScreen;

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
            if (_levelID == LevelTracker.LevelsPassed)
            {
                PlayerPrefs.SetInt("levelsPassed", LevelTracker.LevelsPassed + 1);
            }
            endingScreen.SetActive(true);
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
