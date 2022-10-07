using UnityEngine;
using UnityEngine.UI;

public class SelecterPanel : MonoBehaviour
{
    [SerializeField] private Button _mall;
    [SerializeField] private Button _tomatoField;
    [SerializeField] private Button _watermelonField;
    [SerializeField] private Button _firstCornField;
    [SerializeField] private Button _secondCornField;
    [SerializeField] private MallPanel _mallPanel;
    [SerializeField] private Angar _angar;
    [SerializeField] private GameObject _groupButtons;
    [SerializeField] private Animator _sceneAnimator;
    [SerializeField] private UIUserInfoBar _userInfoBar;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private SceneAnimations _sceneAnimations;

    private  int _moveToFirstCornFieldHash ;
    private  int _moveToSecondCornFieldHash ;
    private  int _moveToTomatoHash ;
    private  int _moveToWotermelonHash;

    private void Awake()
    {
        _moveToWotermelonHash = Animator.StringToHash("MoveToWotermelon");
        _moveToTomatoHash = Animator.StringToHash("MoveToTomato");
        _moveToSecondCornFieldHash = Animator.StringToHash("MoveToSecondCorn");
        _moveToFirstCornFieldHash = Animator.StringToHash("MoveToFirstCorn");

        _mall.enabled = true;
        _tomatoField.enabled = true;
        _watermelonField.enabled = true;
        _firstCornField.enabled = true;
        _secondCornField.enabled = true;

        _groupButtons.gameObject.SetActive(true);
        _mallPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _sceneAnimations.EndAnimation += OnSelectField;
    }

    private void OnDisable()
    {
        _sceneAnimations.EndAnimation -= OnSelectField;
    }

    public void PushMall()
    {
        _userInfoBar.gameObject.SetActive(false);
        _mallPanel.gameObject.SetActive(true);
        _groupButtons.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitMallPanel()
    {
        Time.timeScale = 1;
        _userInfoBar.gameObject.SetActive(true);
        _mallPanel.gameObject.SetActive(false);
        _groupButtons.SetActive(true);
    }

    public void OnSelectField()
    {
        _groupButtons.SetActive(false);
        _sceneChanger.ChangeScene(2);
    }

    public void PushFirstCorn()
    {
        _groupButtons.SetActive(false);
        _sceneAnimator.SetTrigger(_moveToFirstCornFieldHash);
    }

    public void PushTomato()
    {
        _groupButtons.SetActive(false);
        _sceneAnimator.SetTrigger(_moveToTomatoHash);
    }

    public void PushWatermelon()
    {
        _groupButtons.SetActive(false);
        _sceneAnimator.SetTrigger(_moveToWotermelonHash);
    }

    public void PushHarvester()
    {
        _userInfoBar.gameObject.SetActive(false);
        _angar.gameObject.SetActive(true);
        _groupButtons.SetActive(false);
        Time.timeScale = 0;
    }

    public void ExitHarvesterPanel()
    {
        Time.timeScale = 1;
        _angar.gameObject.SetActive(false);
        _userInfoBar.gameObject.SetActive(true);        
        _groupButtons.SetActive(true);     
    }
}
