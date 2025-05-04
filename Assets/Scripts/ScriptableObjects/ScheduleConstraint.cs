using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScheduleConstraint", menuName = "ScriptableObjects/ScheduleConstraint", order = 5)]
public class ScheduleConstraint : ScriptableObject
{
    [Header("日期范围 (包含)")]
    public int minDay = 1;
    public int maxDay = 60;

    [Header("可触发时段 (1: 上午, 2: 下午, 3: 晚上)")]
    public List<int> validSlots = new List<int>();

    [Header("好感度需求 (可选)")]
    public CharacterData affinityCharacter;
    [Range(0, 100)] public int minAffinity = 0;
    [Range(0, 100)] public int maxAffinity = 100;

    /// <summary>
    /// 判断当前时间与好感度是否满足触发条件
    /// </summary>
    /// <param name="currentDay">当前第几天</param>
    /// <param name="currentSlot">当前时段 (1~3)</param>
    /// <param name="affinityProvider">AffinityManager</param>
    public bool IsMet(int currentDay, int currentSlot, object affinityProvider)
    {
        // 日期限制
        if (currentDay < minDay || currentDay > maxDay)
            return false;

        // 时段限制
        if (validSlots != null && validSlots.Count > 0 && !validSlots.Contains(currentSlot))
            return false;

        // 好感度限制
        if (affinityCharacter != null)
        {
            int aff = AffinityManager.Instance.GetAffinity(affinityCharacter);
            if (aff < minAffinity || aff > maxAffinity)
                return false;
        }

        return true;
    }
}