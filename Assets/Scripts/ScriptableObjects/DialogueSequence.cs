using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSequence", menuName = "ScriptableObjects/DialogueSequence", order = 4)]
public class DialogueSequence : ScriptableObject
{
    [Tooltip("对话行列表，按顺序播放")]  
    public List<DialogueLine> lines = new List<DialogueLine>();
}

[Serializable]
public class DialogueLine
{
    [Tooltip("发言角色，None 表示旁白")]
    public CharacterData speaker;

    [TextArea(2, 5)]
    [Tooltip("该角色的对话内容")]  
    public string content;

    [Tooltip("对话行播放完毕后等待的秒数")]  
    public float delayAfter = 0.5f;
}