using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Sprite _image;

    public Sprite GetImage()
    {
        return _image;
    }
}
