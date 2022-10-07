using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHarvesterPanel : MonoBehaviour
{
    [SerializeField] private Harvester _harvesterParametr;
    [SerializeField] private List<GameObject> ItemSlots;

    private void OnEnable()
    {
        _harvesterParametr.BuySparePart += Initialize;
    }

    private void OnDisable()
    {
        _harvesterParametr.BuySparePart -= Initialize;
    }

    private void Initialize(List<Item> sparePart)
    {       
        for (int i = 0; i < sparePart.Count; i++)
        {
            ItemSlots[i].GetComponent<Image>().sprite = sparePart[i].Icon;
        }
    }
}
