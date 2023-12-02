using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonClickEvent<T> : ScriptableObject
{   
    List<ButtonClickEventListener<T>> listeners = new List<ButtonClickEventListener<T>>();

    public void TriggerEvent(T thing)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventTriggered(thing);
        }
    }
    public void AddListener(ButtonClickEventListener<T> listener)
    {
        listeners.Add(listener);

    }
    public void RemoveListener(ButtonClickEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}


