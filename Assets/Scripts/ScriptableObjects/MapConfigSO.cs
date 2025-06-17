using UnityEngine;

/// <summary>
/// 配置一个地图点的信息，包括名称、场景名和缩略图。
/// </summary>
[CreateAssetMenu(fileName = "NewMapPoint", menuName = "Map/MapConfigSO")]
public class MapConfigSO : ScriptableObject
{
    [Tooltip("地图点的唯一ID")]
    public string pointID;

    [Tooltip("地图点在UI上的显示名称")]
    public string displayName;

    [Tooltip("对应的场景名称，用于加载场景或对话")]
    public string sceneName;

    [Tooltip("地图缩略图，用于地图界面显示")]
    public Sprite thumbnail;

    [Tooltip("触发此地图点的初始对话ID（DialogueData asset 名称，无扩展名）")]
    public string initialDialogueID;
}