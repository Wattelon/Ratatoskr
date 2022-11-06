using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject[] orders;
    [SerializeField] private Vector3 orderOffset;
    [SerializeField] private float targetOffset;
    [SerializeField] private float pathTime;
    
    private GameObject _order;
    private int _randomOrder;
    private bool _isOntargetOffset;
    private bool _isOrderTaken;
    private float _runningTime;
    private Vector3 _startPos;

    
    
    private void Start()
    {
        _startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SpriteRenderer>().color == _order.GetComponent<SpriteRenderer>().color)
        {
            Destroy(col.gameObject);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _isOrderTaken = true;
            Destroy(gameObject, 2f);
        }
    }

    private void Update()
    {
        if (!_isOntargetOffset)
        {
            _runningTime += Time.deltaTime;
            if (_runningTime / pathTime > math.PI / 2)
            {
                _runningTime = 0;
                _isOntargetOffset = true;
                MakeOrder();
                transform.position = _startPos + new Vector3(targetOffset, 0);
            }
            else
            {
                transform.position = _startPos + new Vector3(targetOffset * math.sin(_runningTime / pathTime), 0);
            }
        }
        
        if (_isOrderTaken && _runningTime / pathTime < math.PI / 2)
        {
            _runningTime += Time.deltaTime;
            if (_runningTime / pathTime > math.PI / 2)
            {
                _runningTime = math.PI / 2 * pathTime;
            }
            transform.position = _startPos + new Vector3(targetOffset * math.sin(_runningTime / pathTime) + targetOffset, 0);
        }
    }

    public void MakeOrder()
    {
        _randomOrder = Random.Range(0, orders.Length);
        _order = Instantiate(orders[_randomOrder], transform.position + orderOffset, Quaternion.identity, transform);
    }
}
