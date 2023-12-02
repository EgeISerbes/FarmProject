using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game EventWP", menuName = "SO variables/Game EventWP")]
public class GameEventWP : ScriptableObject
{
    List<GameEventListenerWP> listeners = new List<GameEventListenerWP>();
    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    public void AddListener(GameEventListenerWP listener)
    {
        listeners.Add(listener);

    }
    public void RemoveListener(GameEventListenerWP listener)
    {
        listeners.Remove(listener);
    }
}
