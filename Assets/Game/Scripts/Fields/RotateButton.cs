using UnityEngine;
using UnityEngine.Events;

public class RotateButton : MonoBehaviour
{
    public event UnityAction<int> ChangeRotation;

    public void OnChangeRotation(int angleRotation)
    {
        ChangeRotation?.Invoke(angleRotation);
    }
}
