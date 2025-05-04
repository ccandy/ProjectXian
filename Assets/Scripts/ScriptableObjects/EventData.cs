using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "ScriptableObjects/EventData", order = 2)]
public class EventData : ScriptableObject
{
    public string eventID;
    public string title;
    public DialogueSequence dialogue;    // 引用对话序列脚本或 ScriptableObject
    public int affinityChange;
    public ScheduleConstraint constraint; // 自定义触发条件类
    public CharacterData targetCharacter;
}