using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 管理游戏内时间和日期。
/// </summary>

public class DateSystem : SingletonMonoBehaviour<DateSystem>
{
    
    public int Year { get; private set; } = 2000;
    public int Month { get; private set; } = 6;
    public int Day { get; private set; } = 1;
    public int Hour { get; private set; } = 8;
    public int Minute { get; private set; } = 0;
    public event Action OnDateChanged;
    
    public void AdvanceTime(int hours, int minutes)
    {
        Minute += minutes;
        Hour += hours + Minute / 60;
        Minute %= 60;
        Day += Hour / 24;
        Hour %= 24;
        NormalizeDate();
        OnDateChanged?.Invoke();
    }
    
    private void NormalizeDate()
    {
        int[] daysInMonth = { 31,28,31,30,31,30,31,31,30,31,30,31 };
        if (DateTime.IsLeapYear(Year)) daysInMonth[1] = 29;
        while (Day > daysInMonth[Month - 1])
        {
            Day -= daysInMonth[Month - 1];
            Month++;
            if (Month > 12)
            {
                Month = 1;
                Year++;
                daysInMonth[1] = DateTime.IsLeapYear(Year) ? 29 : 28;
            }
        }
    }
    
    public string GetDateString() => $"{Year:D4}-{Month:D2}-{Day:D2} {Hour:D2}:{Minute:D2}";

    public void SetDate(int year, int month, int day, int hour, int minute)
    {
        Year = year; Month = month; Day = day; Hour = hour; Minute = minute;
        OnDateChanged?.Invoke();
    }
}




