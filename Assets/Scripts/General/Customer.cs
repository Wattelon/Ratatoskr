using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Customer : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject orderPrefab;
    [SerializeField] private float waitingTime;
    [SerializeField] private List<string> reactions;
    [SerializeField] private List<Color> orderBubbleColors;

    private Image _image;
    private GameObject _currentOrder;
    private Revenue _revenueCounter;
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
        transform.parent.GetComponent<LevelEnd>().AddMaxGain(CurOrder.Price);
        _image.sprite = CurCustomer.CustomerSprite;
        _revenueCounter = FindObjectOfType<Revenue>();
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
                _image.raycastTarget = false;
                Leave(Reaction.Bad, 0);
            }
        }
    }
    
    private void MakeOrder()
    {
        _currentOrder = Instantiate(orderPrefab, transform);
        _currentOrder.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }

    private void AssessFood(Food food)
    {
        _image.raycastTarget = false;
        if (food.FoodType == CurOrder.FoodType)
        {
            if (food.FoodProcessing is Processing.Raw or Processing.Burned)
            {
                Leave(Reaction.Bad, food.Price);
            }
            else if (food.FoodProcessing == Processing.Cooked)
            {
                Leave(Reaction.Good, food.Price);
            }
            else if (food.FoodProcessing == Processing.Perfect)
            {
                Leave(Reaction.Perfect, food.Price);
            }
            Destroy(food.gameObject);
        }
        else
        {
            Destroy(food.gameObject);
            Leave(Reaction.Bad, food.Price);
        }
    }

    private void Leave(Reaction reaction, int price)
    {
        _currentOrder.GetComponent<Image>().color = orderBubbleColors[(int)reaction];
        _currentOrder.transform.GetChild(0).GetComponent<Image>().enabled = false;
        _revenueCounter.EarnGold(price * (int)reaction);
        _currentOrder.GetComponentInChildren<TextMeshProUGUI>().text = reactions[(int)reaction];
        _isOrderTaken = true;
        transform.DOMoveX(-300, 1.99f);
        Destroy(gameObject, 2f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out Food food))
        {
            AssessFood(food);
        }
    }
}