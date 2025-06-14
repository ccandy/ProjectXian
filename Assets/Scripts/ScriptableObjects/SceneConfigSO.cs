using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储场景配置的数据，包括场景名称、背景、BGM 和可交互物体列表。
/// </summary>
[CreateAssetMenu(fileName = "NewSceneConfig", menuName = "Scene/SceneConfigSO")]
public class SceneConfigSO : ScriptableObject
{
    /// <summary>
    /// 场景在 Unity 中的名称，用于加载。
    /// </summary>
    public string sceneName;

    /// <summary>
    /// 在 UI 或对话中显示的场景标题。
    /// </summary>
    public string displayName;

    /// <summary>
    /// 场景背景图。
    /// </summary>
    public Sprite backgroundImage;

    /// <summary>
    /// 场景默认播放的背景音乐。
    /// </summary>
    public AudioClip defaultBgm;

    /// <summary>
    /// 场景中需要关联的可交互物体预设列表。
    /// </summary>
    public List<GameObject> interactables = new List<GameObject>();

    /// <summary>
    /// 该场景的初始日期和时间（可选覆盖全局时间）。
    /// </summary>
    public int startHour = 8;
    public int startMinute = 0;

    /// <summary>
    /// 加载场景时自动推进的时间（小时）。
    /// </summary>
    public int advanceHoursOnLoad = 0;
}