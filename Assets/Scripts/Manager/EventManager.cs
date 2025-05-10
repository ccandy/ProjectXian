using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private Dictionary<string, Action<object>> eventTable = new Dictionary<string, Action<object>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
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