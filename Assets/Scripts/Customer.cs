using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject[] wishes;
    private GameObject _wish;
    
    void Start()
    {
        _wish = Instantiate(wishes[Random.Range(0, wishes.Length)], new Vector2(1, 1), Quaternion.identity, transform);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SpriteRenderer>().color == _wish.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
