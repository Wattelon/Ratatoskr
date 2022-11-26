using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    [SerializeField] private GameObject[] orders;
    [SerializeField] private Vector3 orderPositionOffset;
    [SerializeField] private float targetPositionOffset;
    [SerializeField] private float pathTime;
    [SerializeField] private float waitingTime;

    private GameObject _order;
    private TextMeshProUGUI _revenueCounter;
    private int _revenue;
    private int _randomOrder;
    private bool _isOnTargetOffset;
    private bool _isOrderTaken;
    private float _runningTime;
    private float _curWaitingTime;
    private Vector3 _startPos;

    
    
    private void Start()
    {
        _startPos = transform.position;
        _revenueCounter = FindObjectOfType<Revenue>().GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<SpriteRenderer>().color == _order.GetComponent<SpriteRenderer>().color)
        {
            Destroy(col.gameObject);
            Destroy(_order);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _isOrderTaken = true;
            _revenue += int.Parse(_revenueCounter.text) + _randomOrder + 1;
            _revenueCounter.text = _revenue.ToString();
            Destroy(gameObject, 2f);
        }
    }

    private void Update()
    {
        if (!_isOnTargetOffset)
        {
            _runningTime += Time.deltaTime;
            if (_runningTime / pathTime > math.PI / 2)
            {
                _runningTime = 0;
                _isOnTargetOffset = true;
                MakeOrder();
                transform.position = _startPos + new Vector3(targetPositionOffset, 0);
            }
            else
            {
                transform.position = _startPos + new Vector3(targetPositionOffset * math.sin(_runningTime / pathTime), 0);
            }
        }
        
        if (_isOnTargetOffset && !_isOrderTaken)
        {
            _curWaitingTime += Time.deltaTime;
            if (_curWaitingTime > waitingTime)
            {
                Destroy(_order);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                _isOrderTaken = true;
                Destroy(gameObject, 2f);
            }
        }

        if (_isOrderTaken && _runningTime / pathTime < math.PI / 2)
        {
            _runningTime += Time.deltaTime;
            if (_runningTime / pathTime > math.PI / 2)
            {
                _runningTime = math.PI / 2 * pathTime;
            }
            transform.position = _startPos + new Vector3(targetPositionOffset * math.sin(_runningTime / pathTime) + targetPositionOffset, 0);
        }
    }

    private void MakeOrder()
    {
        _randomOrder = Random.Range(0, orders.Length);
        _order = Instantiate(orders[_randomOrder], transform.position + orderPositionOffset, Quaternion.identity, transform);
    }
}
