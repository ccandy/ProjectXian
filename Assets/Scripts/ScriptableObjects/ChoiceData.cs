using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储对话选项的 ScriptableObject。
/// 当对话需要提供多种选择时使用。
/// </summary>
[CreateAssetMenu(fileName = "NewChoice", menuName = "Dialogue/ChoiceData")]
public class ChoiceData : ScriptableObject
{
    /// <summary>
    /// 多个选项列表，每个选项包含文本、下一个对话和可能的状态变化。
    /// </summary>
    public List<ChoiceOption> options = new List<ChoiceOption>();
}

/// <summary>
/// 单个对话选项的数据结构。
/// </summary>
[System.Serializable]
public class ChoiceOption
{
    /// <summary>
    /// 选项在 UI 上显示的文本。
    /// </summary>
    public string optionText;

    /// <summary>
    /// 选中该选项后跳转到的下一个对话。
    /// </summary>
    public DialogueData nextDialogue;

    /// <summary>
    /// 选项触发的好感度变化量。
    /// </summary>
    public int affectionChange;

    /// <summary>
    /// 选项触发的时间推进，单位：小时。
    /// </summary>
    public int advanceHours;
}