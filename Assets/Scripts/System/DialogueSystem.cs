// DialogueSystem.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动态加载对话脚本与角色配置，并驱动 UI 显示对话。
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("资源路径设置")]
    [Tooltip("Resources 文件夹下对话 SO 的子路径，例如 'Dialogues/'")]
    public string dialogueResourcePath = "Dialogues/";
    [Tooltip("Resources 文件夹下角色配置 SO 的子路径，例如 'Profiles/'")]
    public string profileResourcePath = "Profiles/";

    [Header("UI 管理器")]
    public DialogueUIManager uiManager;

    private Queue<DialogueLine> linesQueue;
    private bool isDialogueActive;

    /// <summary>
    /// 根据对话资源名称动态加载并启动对话。
    /// </summary>
    /// <param name="dialogueId">SO 文件名（不含扩展名）</param>
    public void StartDialogue(string dialogueId)
    {
        // 加载对话数据
        DialogueData dialogueData = Resources.Load<DialogueData>(dialogueResourcePath + dialogueId);
        if (dialogueData == null)
        {
            Debug.LogError($"未找到对话资源：{dialogueResourcePath + dialogueId}");
            return;
        }

        // 初始化队列
        linesQueue = new Queue<DialogueLine>(dialogueData.lines);
        isDialogueActive = true;

        // 加载首行角色立绘
        LoadAndShowNextLine();
    }

    private void Update()
    {
        if (!isDialogueActive)
            return;

        // 按空格或点击鼠标左键翻页
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            LoadAndShowNextLine();
        }
    }

    /// <summary>
    /// 加载队列中下一行台词并显示。
    /// </summary>
    private void LoadAndShowNextLine()
    {
        if (linesQueue == null || linesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine line = linesQueue.Dequeue();

        // 加载角色配置 SO 并取立绘
        CharacterProfileSO profile = Resources.Load<CharacterProfileSO>(profileResourcePath + line.characterName);
        Sprite portrait = profile != null ? profile.portrait : null;

        // 传递给 UIManager 显示
        uiManager.ShowDialogueLine(line, portrait);
    }

    /// <summary>
    /// 结束对话。
    /// </summary>
    private void EndDialogue()
    {
        uiManager.EndDialogue();
        isDialogueActive = false;
    }
}
