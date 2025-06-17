using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 负责在屏幕上渲染对话框、角色立绘和台词，支持自动换行。
/// 由 DialogueSystem 调用 ShowDialogueLine 和 EndDialogue 方法。
/// </summary>
public class DialogueUIManager : MonoBehaviour
{
    [Header("UI 组件")]
    [Tooltip("对话框背景图的 Image 组件")]
    public Image dialogueBoxBackground;

    [Tooltip("角色立绘的 Image 组件")]
    public Image characterPortrait;

    [Tooltip("显示角色姓名的 Text 组件")]
    public Text nameText;

    [Tooltip("显示对话内容的 Text 组件")]
    public Text dialogueText;

    private void Awake()
    {
        // 初始时隐藏所有对话 UI
        EndDialogue();
    }

    /// <summary>
    /// 显示一行对话，包括角色立绘和文本内容，UI Text 会自动根据 RectTransform 换行。
    /// </summary>
    /// <param name="line">对话数据行 (DialogueLine)</param>
    /// <param name="portrait">角色立绘纹理</param>
    public void ShowDialogueLine(DialogueLine line, Sprite portrait)
    {
        // 设置角色立绘
        if (portrait != null)
        {
            characterPortrait.sprite = portrait;
            characterPortrait.gameObject.SetActive(true);
        }
        else
        {
            characterPortrait.gameObject.SetActive(false);
        }

        // 显示对话框背景
        dialogueBoxBackground.gameObject.SetActive(true);

        // 填入角色名和对话内容
        nameText.text = line.characterName;
        dialogueText.text = line.content;
    }

    /// <summary>
    /// 结束对话，隐藏所有对话相关的 UI。
    /// </summary>
    public void EndDialogue()
    {
        nameText.text = string.Empty;
        dialogueText.text = string.Empty;
        dialogueBoxBackground.gameObject.SetActive(false);
        characterPortrait.gameObject.SetActive(false);
    }
}

/// <summary>
/// 单条对话数据结构引用自 DialogueData 的 DialogueLine。
/// 这里无需重新定义。
/// </summary>