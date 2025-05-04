using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance { get; private set; }

    public int CurrentDay { get; private set; }
    public int CurrentSlot { get; private set; }
    private ScheduleConfig config;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 初始化日程控制器
    /// </summary>
    public void Init()
    {
        config = Resources.Load<ScheduleConfig>("ScheduleConfig");
        CurrentDay = 1;
        CurrentSlot = 1;
        UIManager.Instance.UpdateTimeUI();
    }

    /// <summary>
    /// 推进到下一个时段，若超出时段数则推进到下一天
    /// </summary>
    public void AdvanceSlot()
    {
        CurrentSlot++;
        if (CurrentSlot > config.slotsPerDay)
        {
            AdvanceDay();
        }
        else
        {
            UIManager.Instance.UpdateTimeUI();
        }
    }

    /// <summary>
    /// 推进到下一天并重置时段
    /// </summary>
    public void AdvanceDay()
    {
        CurrentDay++;
        CurrentSlot = 1;
        UIManager.Instance.UpdateCalendar();
        UIManager.Instance.UpdateTimeUI();
    }

    /// <summary>
    /// 手动设置当前日期和时段（用于读档）
    /// </summary>
    public void SetDate(int day, int slot)
    {
        CurrentDay = day;
        CurrentSlot = slot;
        UIManager.Instance.UpdateCalendar();
        UIManager.Instance.UpdateTimeUI();
    }
}