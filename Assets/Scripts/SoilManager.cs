using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilManager : MonoBehaviour
{
    private int _soilHealth;
    private List<ISoilObserver> _observers = new List<ISoilObserver>();

    public int SoilHealth
    {
        get
        {
            return _soilHealth;
        }
        set
        {
            _soilHealth = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(ISoilObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ISoilObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (ISoilObserver observer in _observers)
        {
            observer.OnSoilHealthChanged(_soilHealth);
        }
    }
}
public interface ISoilObserver
{
    void OnSoilHealthChanged(int soilHealth);
}

