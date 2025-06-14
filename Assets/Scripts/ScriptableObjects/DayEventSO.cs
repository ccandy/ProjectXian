using UnityEngine;

/// <summary>
/// 存储基于日期或特定时间点触发的事件配置。
/// </summary>
[CreateAssetMenu(fileName = "NewDayEvent", menuName = "Event/DayEventSO")]
public class DayEventSO : ScriptableObject
{
    /// <summary>
    /// 事件触发的月份 (1-12)。
    /// </summary>
    [Range(1, 12)]
    public int month;

    /// <summary>
    /// 事件触发的日期 (1-31)。
    /// </summary>
    [Range(1, 31)]
    public int day;

    /// <summary>
    /// 事件触发的小时 (0-23)。
    /// </summary>
    [Range(0, 23)]
    public int hour;

    /// <summary>
    /// 事件触发的分钟 (0-59)。
    /// </summary>
    [Range(0, 59)]
    public int minute;

    /// <summary>
    /// 触发该事件所需的最小好感度值。
    /// </summary>
    public int requiredAffection = 0;

    /// <summary>
    /// 触发后要播放的对话数据。
    /// </summary>
    public DialogueData eventDialogue;

    /// <summary>
    /// 是否只触发一次，触发后自动禁用。
    /// </summary>
    public bool singleUse = true;
}