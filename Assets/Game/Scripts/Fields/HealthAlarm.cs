using System.Collections;
using UnityEngine;

public class HealthAlarm : MonoBehaviour
{
    [SerializeField] private SceneChanger _sceneChanger;
    [SerializeField] private HarvesterHealth _harvesterHealth;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        _harvesterHealth.Dead += OnDead;
    }

    public void OnDisable()
    {
        _harvesterHealth.Dead -= OnDead;
    }

    private IEnumerator AlarmEndFuel()
    {
        float timeBeforeChangeScene = 3f;
        gameObject.SetActive(true);

        while (timeBeforeChangeScene > 0)
        {
            yield return new WaitForSeconds(Time.fixedDeltaTime);
            timeBeforeChangeScene -= Time.fixedDeltaTime;
        }

        _sceneChanger.ChangeScene(1);
        StopCoroutine(AlarmEndFuel());
    }

    private void OnDead()
    {
        gameObject.SetActive(true);
        StartCoroutine(AlarmEndFuel());
    }
}
