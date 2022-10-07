using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lebel;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButtonn;

    private Item _item;
    public event UnityAction<Item, SlotView> SellButtonClick;

    public void Render(Item item)
    {
        _item = item;
        _lebel.text = item.Lable;
        _price.text = Convert.ToString(item.Price);
        _icon.sprite = item.Icon;
    }

    private void OnEnable()
    {
        _sellButtonn.onClick.AddListener(OnButtonClick);
        _sellButtonn.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButtonn.onClick.RemoveListener(OnButtonClick);
        _sellButtonn.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (_item.IsBuyed)
        {
            _sellButtonn.interactable = false;
        }
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
    }
}
