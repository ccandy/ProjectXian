using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : SingletonMonoBehaviour<EventManager>
{
    public static EventManager Instance { get; private set; }

    private Dictionary<string, Action<object>> eventTable = new Dictionary<string, Action<object>>();
    public void Subscribe(string eventName, Action<object> listener)
    {
        if (!eventTable.ContainsKey(eventName))
            eventTable[eventName] = delegate { };
        eventTable[eventName] += listener;
    }
    
    public void Unsubscribe(string eventName, Action<object> listener)
    {
        if (eventTable.ContainsKey(eventName))
            eventTable[eventName] -= listener;
    }
    
    public void TriggerEvent(string eventName, object param = null)
    {
        if (eventTable.ContainsKey(eventName))
            eventTable[eventName]?.Invoke(param);
    }

    


    
}