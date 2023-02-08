using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Customer : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject orderPrefab;
    [SerializeField] private Vector3 orderPositionOffset;
    [SerializeField] private float waitingTime;

    private Image _image;
    private GameObject _currentOrder;
    private TextMeshProUGUI _revenueCounter;
    private int _revenue;
    private int _orderIndex;
    private bool _isOnTargetOffset;
    private bool _isOrderTaken;
    private float _runningTime;
    private float _curWaitingTime;

    public CustomerSO CurCustomer;
    public FoodSO CurOrder { get; private set; }

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        CurOrder = CurCustomer.Order;
        _image.sprite = CurCustomer.CustomerSprite;
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
        _currentOrder = Instantiate(orderPrefab, transform.position + orderPositionOffset, Quaternion.identity, transform);
    }

    private void AccessFood(Food food)
    {
        if (food.FoodType == CurOrder.FoodType)
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
        _isOrderTaken = true;
        transform.DOMoveX(-100, 2f);
        Destroy(gameObject, 2f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out Food food))
        {
            AccessFood(food);
        }
    }
}