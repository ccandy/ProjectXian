using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储游戏日历中的节日和特殊活动配置。
/// </summary>
[CreateAssetMenu(fileName = "NewCalendarConfig", menuName = "Calendar/CalendarConfigSO")]
public class CalendarConfigSO : ScriptableObject
{
    /// <summary>
    /// 节日或活动列表。
    /// </summary>
    public List<HolidayInfo> holidays = new List<HolidayInfo>();

    [System.Serializable]
    public class HolidayInfo
    {
        /// <summary>
        /// 节日月份 (1-12)。
        /// </summary>
        [Range(1, 12)] public int month;
        /// <summary>
        /// 节日日期 (1-31)。
        /// </summary>
        [Range(1, 31)] public int day;
        /// <summary>
        /// 节日名称，用于 UI 显示。
        /// </summary>
        public string holidayName;
        /// <summary>
        /// 可选：在节日当天触发的对话。
        /// </summary>
        public DialogueData festiveDialogue;
    }
}