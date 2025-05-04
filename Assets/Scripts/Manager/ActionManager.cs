using System;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static ActionManager Instance { get; private set; }
    private Dictionary<int, List<ActionEntry>> actionsPerSlot;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitActions();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>初始化每日时段动作字典并添加默认动作</summary>
    private void InitActions()
    {
        actionsPerSlot = new Dictionary<int, List<ActionEntry>>();
        int maxSlots = 3;
        for (int slot = 1; slot <= maxSlots; slot++)
        {
            actionsPerSlot[slot] = new List<ActionEntry>();
        }
    }

    private void AddAction(int slot, string name, Action callback)
    {
        if (actionsPerSlot.ContainsKey(slot))
            actionsPerSlot[slot].Add(new ActionEntry { name = name, callback = callback });
    }

    /// <summary>获取当前时段所有动作名称</summary>
    public List<string> GetActionsForCurrentSlot()
    {
        int slot = TimeController.Instance.CurrentSlot;
        if (actionsPerSlot.TryGetValue(slot, out var list))
        {
            var names = new List<string>();
            foreach (var e in list) names.Add(e.name);
            return names;
        }
        return new List<string>();
    }

    /// <summary>执行指定动作并推进时段</summary>
    public void ExecuteAction(string actionName)
    {
        int slot = TimeController.Instance.CurrentSlot;
        if (actionsPerSlot.TryGetValue(slot, out var list))
        {
            foreach (var e in list)
            {
                if (e.name == actionName)
                {
                    e.callback?.Invoke();
                    return;
                }
            }
        }
    }

    private class ActionEntry { public string name; public Action callback; }
}
