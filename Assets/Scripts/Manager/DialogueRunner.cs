/* --------------------------------------------------------------------------
   DialogueRunner.cs
   单例模式：启动对话并回调
   -------------------------------------------------------------------------- */
using System;
using UnityEngine;

public class DialogueRunner : MonoBehaviour
{
    public static DialogueRunner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }
    }

    /// <summary>
    /// 启动对话序列，完成后回调
    /// </summary>
    public void StartDialogue(DialogueSequence sequence, Action onComplete)
    {
        UIManager.Instance.ShowDialogue(sequence, onComplete);
    }
}