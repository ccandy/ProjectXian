using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("日历和时间显示")] public CalendarUI calendarUI;
    public Text timeText;

    [Header("角色好感面板")] public AffinityUI affinityUI;

    [Header("对话面板")] public DialogueUI dialogueUI;

    [Header("可选动作面板")] public ActionMenuUI actionMenuUI;

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    public static void Init()
    {
        if (Instance == null) Debug.LogError("UIManager 未初始化");
        else
        {
            Instance.UpdateCalendar();
            Instance.UpdateTimeUI();
        }
    }

    public void UpdateCalendar()
    {
        calendarUI.SetDay(TimeController.Instance.CurrentDay);
    }

    public void UpdateTimeUI()
    {
        int slot = TimeController.Instance.CurrentSlot;
        string label = slot == 1 ? "上午" : slot == 2 ? "下午" : "晚上";
        timeText.text = $"第 {TimeController.Instance.CurrentDay} 天 · {label}";
    }

    public void UpdateAffinityUI(CharacterData ch, int newVal)
    {
        affinityUI.SetAffinity(ch, newVal);
    }

    public void ShowAvailableActions()
    {
        List<string> actions = ActionManager.Instance.GetActionsForCurrentSlot();
        actionMenuUI.ShowActions(actions, selectedAction =>
        {
            ActionManager.Instance.ExecuteAction(selectedAction);
        });
    }

    public void ShowDialogue(DialogueSequence seq, System.Action onComplete)
    {
        dialogueUI.PlaySequence(seq, onComplete);
    }
}