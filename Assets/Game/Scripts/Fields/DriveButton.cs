using UnityEngine;
using UnityEngine.Events;

public class DriveButton : MonoBehaviour
{
    public event UnityAction<int> ChangeDirection;

    public void OnChangeDirection(int buttonDirection)
    {
        ChangeDirection?.Invoke(buttonDirection);
    }
}
