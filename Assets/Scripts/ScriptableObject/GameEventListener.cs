using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventListener<T> : MonoBehaviour
{
    public GameEvent<T> gameEvent;
    public GameEventAction<T> onEventTriggered;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventTriggered(T type)
    {
        onEventTriggered.Invoke(type);
    }

}
[System.Serializable]
public class GameEventAction<T> : UnityEvent<T>
{

}