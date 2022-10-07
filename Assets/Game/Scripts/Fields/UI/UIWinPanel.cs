using System.Collections;
using UnityEngine;

public class UIWinPanel : MonoBehaviour
{
    [SerializeField] private Reel _reel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private GameObject _buttomGroup;
    
    private int _winningNumber;
    private int _count;

    private void Start()
    {
        _winPanel.SetActive(false);
        _winningNumber = 7;
    }

    private void OnEnable()
    {
        _reel.DieZombi += OnChangeCount;
    }

    private void OnChangeCount()
    {
        _count++;

        if (_count>=_winningNumber)
        {
            StartCoroutine(ShowWinPanel());
            _reel.DieZombi -= OnChangeCount;
        }
    }

    private IEnumerator ShowWinPanel()
    {
        _winPanel.SetActive(true);
        _buttomGroup.SetActive(false);

        float timeBeforeChangeScene = 4f;

        while (timeBeforeChangeScene > 0)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            timeBeforeChangeScene -= Time.fixedDeltaTime;
        }

        _sceneChanger.ChangeScene(1);
        StopCoroutine(ShowWinPanel());
    }
}
