/* --------------------------------------------------------------------------
   DialogueUI.cs
   对话面板脚本：播放 DialogueSequence 中的对话行
   -------------------------------------------------------------------------- */
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("对话面板根节点")] public GameObject dialoguePanel;
    [Header("角色头像")] public Image portraitImage;
    [Header("角色名称文本")] public Text nameText;
    [Header("对话内容文本")] public Text contentText;
    [Header("下一步按钮")] public Button nextButton;

    private DialogueSequence currentSequence;
    private Action onComplete;
    private int currentIndex;

    private void Awake()
    {
        dialoguePanel.SetActive(false);
        nextButton.onClick.AddListener(OnNextClicked);
    }

    /// <summary>
    /// 播放整个对话序列，结束后执行回调
    /// </summary>
    public void PlaySequence(DialogueSequence sequence, Action onComplete)
    {
        currentSequence = sequence;
        this.onComplete = onComplete;
        currentIndex = 0;
        dialoguePanel.SetActive(true);
        ShowLine();
    }

    private void ShowLine()
    {
        if (currentIndex >= currentSequence.lines.Count)
        {
            EndDialogue();
            return;
        }

        var line = currentSequence.lines[currentIndex];
        // 更新 UI
        if (line.speaker != null)
        {
            portraitImage.sprite = line.speaker.portrait;
            nameText.text = line.speaker.characterName;
        }
        else
        {
            portraitImage.sprite = null;
            nameText.text = string.Empty;
        }
        contentText.text = line.content;

        // 如果 delayAfter > 0，则自动进入下一行（可选），否则等待玩家点击
        StopAllCoroutines();
        if (line.delayAfter > 0)
        {
            StartCoroutine(AutoNext(line.delayAfter));
        }
    }

    private IEnumerator AutoNext(float delay)
    {
        yield return new WaitForSeconds(delay);
        Advance();
    }

    private void OnNextClicked()
    {
        Advance();
    }

    private void Advance()
    {
        currentIndex++;
        ShowLine();
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        onComplete?.Invoke();
    }
}
