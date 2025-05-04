/* --------------------------------------------------------------------------
   CalendarUI.cs
   日历界面脚本：显示当前天数，并管理时段格子状态
   -------------------------------------------------------------------------- */
using UnityEngine;
using UnityEngine.UI;

public class CalendarUI : MonoBehaviour
{
    [Header("日历标题 (显示当前第几天)")]
    public Text dayText;

    [Header("时段格子父物体")]  
    public Transform slotsParent; // 包含子物体按钮或图标，数量与 slotsPerDay 一致

    [Header("格子高亮颜色")]  
    public Color highlightedColor;
    [Header("格子默认颜色")]  
    public Color defaultColor;

    /// <summary>
    /// 更新日历界面，当日标题与所有格子设为可选默认状态
    /// </summary>
    public void SetDay(int day)
    {
        if (dayText != null)
            dayText.text = $"Day {day}";
        // 重置格子颜色
        for (int i = 0; i < slotsParent.childCount; i++)
        {
            var img = slotsParent.GetChild(i).GetComponent<Image>();
            if (img != null)
                img.color = defaultColor;
        }
    }

    /// <summary>
    /// 高亮指定时段格子 (1-上午,2-下午,3-晚上)
    /// </summary>
    public void HighlightSlot(int slotIndex)
    {
        int idx = slotIndex - 1;
        if (idx >= 0 && idx < slotsParent.childCount)
        {
            var img = slotsParent.GetChild(idx).GetComponent<Image>();
            if (img != null)
                img.color = highlightedColor;
        }
    }
}