using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class SceneAnimations : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private UICornFirstField _cornFirstFieldUI;
    [SerializeField] private UICornSecondField _cornSecondFieldUI;
    [SerializeField] private UITomatoField _tomatoFieldUI;
    [SerializeField] private UIWatermelonField _watermelonFieldUI;
    [SerializeField] private AlarmHarvester _alarm;

    public UnityAction EndAnimation;

    private int _isSelectFirstCornHash;
    private int _isSelectSecondCornHash;
    private int _isSelectTomatoHash;
    private int _isSelectWotermelonHAsh;


    private void Awake()
    {
        _alarm.gameObject.SetActive(false);
        _animator =GetComponent<Animator>();
        _isSelectFirstCornHash = Animator.StringToHash("IsSelectFirstCorn");
        _isSelectSecondCornHash = Animator.StringToHash("IsSelectSecondCorn");
        _isSelectTomatoHash = Animator.StringToHash("IsSelectTomato");
        _isSelectWotermelonHAsh = Animator.StringToHash("IsSelectWotermelon");
    }


    private void OnEnable()
    {
        _cornFirstFieldUI.ClickFirstFieldButton += OnClickCornFirstField;
        _cornSecondFieldUI.ClickCornSecondFieldButton += OnClickCornSecondField;
        _tomatoFieldUI.ClickTomatoFieldButton += OnClickTomatoField;
        _watermelonFieldUI.ClickWatermelonFieldButton += OnClickWatermelonField;
    }

    private void OnDisable()
    {
        _cornFirstFieldUI.ClickFirstFieldButton -= OnClickCornFirstField;
        _cornSecondFieldUI.ClickCornSecondFieldButton -= OnClickCornSecondField;
        _tomatoFieldUI.ClickTomatoFieldButton-= OnClickTomatoField;
        _watermelonFieldUI.ClickWatermelonFieldButton -= OnClickWatermelonField;
    }


    private void OnClickCornFirstField()
    {
        _animator.SetBool(_isSelectFirstCornHash, true);        
    }

    private void OnClickCornSecondField()
    {
        _animator.SetBool(_isSelectSecondCornHash, true);
    }

    private void OnClickTomatoField()
    {
        _animator.SetBool(_isSelectTomatoHash, true);
    }

    private void OnClickWatermelonField()
    {
        _animator.SetBool(_isSelectWotermelonHAsh, true);
    }

    public void OnEndAnimation()
    {
        EndAnimation?.Invoke();
    }

    public void OnStartAnimationAlart()
    {
        _alarm.gameObject.SetActive(true);
    }

    public void OnEndAnimationAlart()
    {
        _alarm.gameObject.SetActive(false);
    }
}
