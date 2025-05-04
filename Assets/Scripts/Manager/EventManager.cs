using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private List<EventData> allEvents;

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

    /// <summary>
    /// 初始化：加载所有 EventData
    /// </summary>
    public void Init()
    {
        allEvents = new List<EventData>(Resources.LoadAll<EventData>("EventData"));
    }

    /// <summary>
    /// 检查并触发满足条件的第一个事件
    /// </summary>
    public void CheckTriggerableEvents()
    {
        foreach (var evt in allEvents)
        {
            if (evt.constraint.IsMet(TimeController.Instance.CurrentDay, TimeController.Instance.CurrentSlot,AffinityManager.Instance))
            {
                StartEvent(evt);
                break;  // 每次只触发一个事件
            }
        }
    }

    /// <summary>
    /// 执行剧情：播放对话，结束时调整好感度
    /// </summary>
    private void StartEvent(EventData evt)
    {
        DialogueRunner.Instance.StartDialogue(evt.dialogue, () =>
        {
            AffinityManager.Instance.ChangeAffinity(evt.targetCharacter, evt.affinityChange);
        });
    }
}