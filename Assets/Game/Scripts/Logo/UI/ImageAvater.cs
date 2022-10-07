using UnityEngine;
using UnityEngine.UI;

public class ImageAvater : MonoBehaviour
{
    private Image _tempImage;
    public Image GetImage()
    {
        _tempImage = gameObject.GetComponent<Image>();
        return _tempImage;
    }
}
