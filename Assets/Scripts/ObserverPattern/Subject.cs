using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    private List<IObserver> m_observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        m_observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        m_observers.Remove(observer);
    }

    protected void NotifyObservers(PlayerAction action)
    {
        m_observers.ForEach(observer => {
            observer.OnNotify(action);
        });
    }
}
