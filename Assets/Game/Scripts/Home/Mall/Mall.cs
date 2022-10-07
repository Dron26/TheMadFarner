using System.Collections.Generic;
using UnityEngine;

public class Mall : MonoBehaviour
{
    [SerializeField] private List<Item> _spareParts;
    [SerializeField] private Player _player;
    [SerializeField] private SlotView _template;
    [SerializeField] private GameObject _sparePartsnContainer;
    [SerializeField] private Harvester _harvester;

    private Wallet _wallet;
    private int amountFertilizers;
    private int _priceFertilizers;

    private void Start()
    {
        _priceFertilizers = 1;
        _wallet = _player.GetComponent<Wallet>();

        for (int i = 0; i < _spareParts.Count; i++)
        {
            AddItem(_spareParts[i], _sparePartsnContainer);
        }  
    }

    private void AddItem(Item item, GameObject container)
    {
        var view = Instantiate(_template, container.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(item);
    }

    public void OnSellButtonClick(Item item, SlotView view)
    {
        TrySellWeAPON(item, view);
    }

    private void TrySellWeAPON(Item item, SlotView view)
    {
        if (item.Price <= _wallet.Money)
        {
            _wallet.RemoveResource(item.Price);
            item.Buy();
            view.SellButtonClick -= OnSellButtonClick;
            _harvester.BuySpareParts( item);
        }
    }

    public void OnSellFertilizersButtonClick()
    {
        amountFertilizers = _harvester.CountReelsKilledZombi;

        if (amountFertilizers>0)
        {
            int count = amountFertilizers / _priceFertilizers;
            _wallet.AddResource(count);
            _harvester.RemoveFertilizers(count);
        }
    }
}
