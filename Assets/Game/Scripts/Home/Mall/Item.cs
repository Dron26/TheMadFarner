using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item Data", order = 51)]

public class Item :ScriptableObject
{
    [SerializeField] private string _lable;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isBuyed = false;

    public string Lable => _lable;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBuyed => _isBuyed;

    public void Buy()
    {
        _isBuyed = true;
    }
}