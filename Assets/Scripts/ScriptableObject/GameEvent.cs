using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameEvent<T> : ScriptableObject
{
    List<GameEventListener<T>> listeners = new List<GameEventListener<T>>();
    public void TriggerEvent(T thing)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(thing);
        }
    }

    public void AddListener(GameEventListener<T> listener)
    {
        listeners.Add(listener);

    }
    public void RemoveListener(GameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}

