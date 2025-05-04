/* --------------------------------------------------------------------------
   ScheduleConfig.cs
   全局日程配置：总天数、时段数、特殊日期
   -------------------------------------------------------------------------- */
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpecialDate
{
    [Tooltip("触发日 (第几天)")]
    public int day;
    [Tooltip("触发时段 (1=上午,2=下午,3=晚上)")]
    public int slot;
    [Tooltip("该时段要触发的特殊事件资源")]  
    public EventData eventData;
}

[CreateAssetMenu(fileName = "ScheduleConfig", menuName = "ScriptableObjects/ScheduleConfig", order = 3)]
public class ScheduleConfig : ScriptableObject
{
    [Header("暑假总天数")]
    [Tooltip("暑假包含的总天数，如 60 天")] public int totalDays = 60;

    [Header("每日时段数")]
    [Tooltip("每天可行动时段数，如 上午/下午/晚上 共 3 时段")] public int slotsPerDay = 3;

    [Header("关键特殊日期列表")]  
    [Tooltip("在特定天与时段强制触发的特殊事件")] public List<SpecialDate> specialDates = new List<SpecialDate>();

    /// <summary>
    /// 获取指定日期与时段的特殊事件配置，如果不存在返回 null
    /// </summary>
    public SpecialDate GetSpecialDate(int currentDay, int currentSlot)
    {
        foreach (var sd in specialDates)
        {
            if (sd.day == currentDay && sd.slot == currentSlot)
                return sd;
        }
        return null;
    }
}