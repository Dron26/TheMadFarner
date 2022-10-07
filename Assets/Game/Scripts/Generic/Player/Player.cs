using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string NameAvater { get; private set; }
    public string ImageName { get=>_imageName; private set { } }
    public bool IsEnterGame { get=> _isEnterGame; private set { } }

    [SerializeField] private UIUserInfoBar _userInfoBar;
    private bool _isEnterGame;

    private string _imageName;
    private string direction;

    public void Initialization( string nameAvatar)
    {
        NameAvater = nameAvatar;
        direction = Application.dataPath + "Game/Sprites/Avatar";
    }

    public void LoadParametr( string imageName)
    {
        _imageName = imageName;

        if (_userInfoBar!=null)
        {
            _userInfoBar.SetAvatar(imageName);
        }
    }

    public void SetAvatarInfo( string imageName)
    {       
        _imageName = imageName;
    }

    public void SetEnterGame(bool isenterGame)
    {
        _isEnterGame = isenterGame;
    }
}
