using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储一条对话序列（包括台词和选项）的 ScriptableObject。
/// </summary>
[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogueData : ScriptableObject
{
    /// <summary>
    /// 对话行列表，每行包含角色、文本内容和好感度变化。
    /// </summary>
    public List<DialogueLine> lines = new List<DialogueLine>();

    /// <summary>
    /// 可选：对话背景图。
    /// </summary>
    public Sprite background;

    /// <summary>
    /// 可选：播放的背景音乐。
    /// </summary>
    public AudioClip bgm;
}

/// <summary>
/// 单条对话数据，包含角色名、文本内容以及好感度变化量。
/// </summary>
[System.Serializable]
public class DialogueLine
{
    /// <summary>
    /// 说话角色的标识或显示名。
    /// </summary>
    public string characterName;

    /// <summary>
    /// 台词文本内容。
    /// </summary>
    [TextArea(2, 5)]
    public string content;

    /// <summary>
    /// 该台词触发的好感度增减值。
    /// </summary>
    public int affectionChange;
}