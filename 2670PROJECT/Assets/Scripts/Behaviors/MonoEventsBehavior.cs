using System;
using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, onEnableEvent, outOfBoundsEvent;

    private void Start()
    {
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    private void OutOfBounds()
    {
        outOfBoundsEvent.Invoke();
    }
}
