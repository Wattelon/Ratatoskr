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
    private Gold _goldCounter;
    private int _revenue;
    private int _orderIndex;
    private bool _isOnTargetOffset;
    private bool _isOrderTaken;
    private float _runningTime;
    private float _curWaitingTime;

    public CustomerSO CurCustomer;
    public FoodSO CurOrder { get; private set; }
    public bool IsOrderCut { get; private set; }
    public bool IsOrderCooked { get; private set; }

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        CurOrder = CurCustomer.Order;
        if (CurOrder.Cutable)
        {
            IsOrderCut = Random.Range(0, 5) > 0;
        }
        if (CurOrder.HeatTreatable)
        {
            IsOrderCooked = Random.Range(0, 5) > 0;
        }
        transform.parent.GetComponent<LevelEnd>().AddMaxGain(CurOrder.Price);
        _image.sprite = CurCustomer.CustomerSprite;
        _goldCounter = FindObjectOfType<Gold>();
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
                Leave(Estimation.Bad, 0);
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
        if (food.FoodType == CurOrder.FoodType && food.IsCut == IsOrderCut)
        {
            if (IsOrderCooked)
            {
                if (food.FoodHeatTreating is HeatTreating.Raw or HeatTreating.Burned)
                {
                    Leave(Estimation.Bad, food.Price);
                }
                else if (food.FoodHeatTreating == HeatTreating.Cooked)
                {
                    Leave(Estimation.Good, food.Price);
                }
                else if (food.FoodHeatTreating == HeatTreating.Perfect)
                {
                    Leave(Estimation.Perfect, food.Price);
                }
            }
            else if (food.FoodHeatTreating == HeatTreating.Raw)
            {
                Leave(Estimation.Perfect, food.Price);
            }
            else
            {
                Leave(Estimation.Bad, food.Price);
            }
            Destroy(food.gameObject);
        }
        else
        {
            Destroy(food.gameObject);
            Leave(Estimation.Bad, food.Price);
        }
    }

    private void Leave(Estimation estimation, int price)
    {
        _currentOrder.GetComponent<Image>().color = orderBubbleColors[(int)estimation];
        _currentOrder.transform.GetChild(0).GetComponent<Image>().enabled = false;
        _goldCounter.EarnGold(price * (int)estimation);
        _currentOrder.GetComponentInChildren<TextMeshProUGUI>().text = reactions[(int)estimation];
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