using UnityEngine;
using  DG.Tweening;

public class HarvesterMoverIn2D : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;

    void Start()
    {
        Tween tween = transform.DOPath(_waypoints, 100, PathType.CatmullRom).SetOptions(true).SetLookAt(0.01f);

        tween.SetLoops(-1);
    }
}
