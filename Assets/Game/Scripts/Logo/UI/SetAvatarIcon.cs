using UnityEngine;
using UnityEngine.UI;

public class SetAvatarIcon : MonoBehaviour
{
    [SerializeField] private LogoUiController _logoUiController;

    public void SetAvatar(GameObject gameObject)
    {
        _logoUiController.SetAvatar(gameObject);
    }
}
