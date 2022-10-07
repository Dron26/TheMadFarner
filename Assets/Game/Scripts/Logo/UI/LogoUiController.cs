using UnityEngine;

public class LogoUiController : MonoBehaviour
{
    [SerializeField] private GameObject _startButton;
    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _animationObjects;
    [SerializeField] private GameObject _avatarPanel;
    [SerializeField] private SceneChanger _changer;
    [SerializeField] private GameObject _animationObject;
    [SerializeField] private Player _player;

    private bool _isFirstStart;

    private void Awake()
    {
        _startButton.SetActive(true);
        _background.SetActive(true);
        _avatarPanel.SetActive(false);
        _animationObjects.SetActive(true);
    }

    public void PushStartButton()
    {
        _animationObject.SetActive(false);

        if (_isFirstStart)
        {
            _isFirstStart = false;
            _startButton.SetActive(false);
            Time.timeScale = 0;
            _avatarPanel.SetActive(true);
        }
        else
        {
            _changer.ChangeScene(1);
        }       
    }

    public void PushAvatarButton()
    {
        _avatarPanel.SetActive(false);
        Time.timeScale = 1;
        _changer.ChangeScene(1);
    }

    public void FirstStart()
    {
        _isFirstStart = true;
    }


    public void SetAvatar(GameObject avatar)
    {
        string _imageName = avatar.name;
        _player.SetAvatarInfo(_imageName);
    }
}
