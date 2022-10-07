using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Image _screenDim;
    [SerializeField] private GameObject _buttonGroup;

    private Save _save;

    private bool _isFirstStart;
    private Color _color;
    private float _waitTime;

    private void Awake()
    {
        _save = GetComponent<Save>();
        _screenDim.gameObject.SetActive(true);
        _color = _screenDim.color;
    }

    private void Start()
    {
        _buttonGroup.SetActive(false);
        StartCoroutine(ChangeColorEnterScene());
    }

    public void ChangeScene(int index)
    {
        StartCoroutine(ChangeColorExitScene(index));
    }

    public void Exit()
    {
        Application.Quit();
    }

    private IEnumerator ChangeColorExitScene(int index)
    {
        _buttonGroup.SetActive(false);
        _screenDim.gameObject.SetActive(true);

        while (_color.a < 1)
        {
            _waitTime = Time.fixedDeltaTime;
            yield return new WaitForSeconds(_waitTime);
            _color.a += _waitTime;
            _screenDim.color = _color;
        }

        
        StopCoroutine(ChangeColorExitScene(index));

        _save.SaveData();
        SceneManager.LoadScene(index);
    }

    private IEnumerator ChangeColorEnterScene()
    {
        while (_color.a > 0)
        {
            _waitTime = Time.fixedDeltaTime;
            yield return new WaitForSeconds(_waitTime);
            _color.a -= _waitTime;
            _screenDim.color = _color;
        }

        _screenDim.gameObject.SetActive(false);
        _buttonGroup.SetActive(true);
        StopCoroutine(ChangeColorEnterScene());
    }

    public void FirstStart()
    {
        _isFirstStart = true;
    }
}