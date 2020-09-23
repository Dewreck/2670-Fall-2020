using UnityEngine;
using UnityEngine.Events;

public class MouseEventsBehavior : MonoBehaviour
{
    public UnityEvent mouseDownEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }
}
