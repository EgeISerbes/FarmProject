using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ButtonClickEventListener<T> : MonoBehaviour
{
    public ButtonClickEvent<T> _buttonClickEvent;
    public ButtonEvent<T> onButtonTriggered;

    private void OnEnable()
    {
        _buttonClickEvent.AddListener(this);
    }
    private void OnDisable()
    {
        _buttonClickEvent.RemoveListener(this);
    }
    public void OnEventTriggered(T thing)
    {   
        
        onButtonTriggered.Invoke(thing);
    }
}
[System.Serializable]
public class ButtonEvent<T> : UnityEvent<T>
{

}

