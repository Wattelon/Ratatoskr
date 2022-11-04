using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject customer;
    void Start()
    {
        Instantiate(customer, Vector2.zero, Quaternion.identity);
    }

    void Update()
    {
        if (!FindObjectOfType<Customer>())
        {
            Instantiate(customer, Vector2.zero, Quaternion.identity);
        }
    }
}
