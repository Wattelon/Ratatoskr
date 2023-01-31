using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{ 
    [SerializeField] private GameObject order;
    [SerializeField] private Vector3 orderPositionOffset;
    [SerializeField] private float waitingTime;

    private Image _image;
    private BoxCollider2D _boxCollider2D;
    private GameObject _currentOrder;
    private TextMeshProUGUI _revenueCounter;
    private int _revenue;
    private int _orderIndex;
    private bool _isOnTargetOffset;
    private bool _isOrderTaken;
    private float _runningTime;
    private float _curWaitingTime;

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _revenueCounter = FindObjectOfType<Revenue>().GetComponent<TextMeshProUGUI>();
        transform.DOMoveX(transform.parent.position.x, 2);
    }

    private void Update()
    {
        if (!_isOnTargetOffset && transform.position == transform.parent.position)
        {
            _isOnTargetOffset = true;
            MakeOrder();
        }
        
        if (_isOnTargetOffset && !_isOrderTaken)
        {
            _curWaitingTime += Time.deltaTime;
            if (_curWaitingTime > waitingTime)
            {
                _image.color = Color.red;
                Leave();
            }
        }
    }
    
    private void MakeOrder()
    {
        _currentOrder = Instantiate(order, transform.position + orderPositionOffset, Quaternion.identity, transform);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Food food))
        {
            AccessFood(food);
        }
        else
        {
            _image.color = Color.red;
            Destroy(col.gameObject);
            Leave();
        }
    }

    private void AccessFood(Food food)
    {
        if (food.FoodType == _currentOrder.GetComponent<Order>().OrderFoodType)
        {
            if (food.FoodProcessing is Processing.Raw or Processing.Burned)
            {
                _image.color = Color.red;
            }
            else if (food.FoodProcessing == Processing.Cooked)
            {
                _revenue += int.Parse(_revenueCounter.text) + food.Price;
                _revenueCounter.text = _revenue.ToString();
                _image.color = Color.yellow;
            }
            else if (food.FoodProcessing == Processing.Perfect)
            {
                _revenue += int.Parse(_revenueCounter.text) + food.Price * 2;
                _revenueCounter.text = _revenue.ToString();
                _image.color = Color.green;
            }

            Destroy(food.gameObject);
            Destroy(_currentOrder);
            Leave();
        }
        else
        {
            _image.color = Color.red;
            Destroy(food.gameObject);
            Leave();
        }
    }

    private void Leave()
    {
        Destroy(_currentOrder);
        _boxCollider2D.enabled = false;
        _isOrderTaken = true;
        transform.DOMoveX(-100, 2f);
        Destroy(gameObject, 2f);
    }
}