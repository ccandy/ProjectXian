using UnityEngine;

/// <summary>
/// 存储角色静态信息和配置的 ScriptableObject。
/// 用于集中管理各角色的基本属性、资源和初始状态。
/// </summary>
[CreateAssetMenu(fileName = "NewCharacterProfile", menuName = "Character/Profile")]
public class CharacterProfileSO : ScriptableObject
{
    /// <summary>
    /// 角色唯一标识（用于代码逻辑索引）。
    /// </summary>
    public string characterID;

    /// <summary>
    /// 在 UI 中显示的角色姓名。
    /// </summary>
    public string displayName;

    /// <summary>
    /// 角色头像或站立绘。
    /// </summary>
    public Sprite portrait;

    /// <summary>
    /// 角色立绘在对话框中的显示图（可选不同姿势）。
    /// </summary>
    public Sprite[] expressions;

    /// <summary>
    /// 初始好感度值。
    /// </summary>
    public int initialAffection = 0;

    /// <summary>
    /// 角色的语音列表，可选发声或台词音效。
    /// </summary>
    public AudioClip[] voiceClips;

    /// <summary>
    /// 角色对话时默认语速或其他参数（如未来拓展）。
    /// </summary>
    public float defaultSpeechSpeed = 1.0f;
}