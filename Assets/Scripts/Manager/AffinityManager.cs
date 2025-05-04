using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 好感度管理器，采用单例模式
/// </summary>
public class AffinityManager : MonoBehaviour
{
    /// <summary>单例实例</summary>
    public static AffinityManager Instance { get; private set; }

    /// <summary>角色与当前好感度映射</summary>
    private Dictionary<CharacterData, int> affinityMap = new Dictionary<CharacterData, int>();

    /// <summary>当角色好感度变化时触发，参数(CharacterData, 当前好感度)</summary>
    public event Action<CharacterData, int> OnAffinityChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 初始化或重置好感度数据
    /// </summary>
    public void Init()
    {
        affinityMap.Clear();
        // 从 Resources/CharacterData 文件夹加载所有角色数据
        var characters = Resources.LoadAll<CharacterData>("CharacterData");
        foreach (var ch in characters)
        {
            affinityMap[ch] = Mathf.Clamp(ch.initialAffinity, 0, 100);
        }
    }

    /// <summary>
    /// 增加或减少某角色的好感度
    /// </summary>
    /// <param name="character">目标角色</param>
    /// <param name="delta">变化量（正数为增加，负数为减少）</param>
    public void ChangeAffinity(CharacterData character, int delta)
    {
        if (character == null || !affinityMap.ContainsKey(character)) return;
        int newVal = Mathf.Clamp(affinityMap[character] + delta, 0, 100);
        affinityMap[character] = newVal;
        OnAffinityChanged?.Invoke(character, newVal);
    }

    /// <summary>
    /// 直接设置某角色的好感度
    /// </summary>
    /// <param name="character">目标角色</param>
    /// <param name="value">新好感度值（0~100）</param>
    public void SetAffinity(CharacterData character, int value)
    {
        if (character == null) return;
        int clamped = Mathf.Clamp(value, 0, 100);
        affinityMap[character] = clamped;
        OnAffinityChanged?.Invoke(character, clamped);
    }

    /// <summary>
    /// 获取某角色当前好感度
    /// </summary>
    /// <param name="character">目标角色</param>
    /// <returns>当前好感度，若角色不存在则返回0</returns>
    public int GetAffinity(CharacterData character)
    {
        if (character == null) return 0;
        return affinityMap.TryGetValue(character, out int val) ? val : 0;
    }

    /// <summary>
    /// 获取所有角色及其好感度的只读字典
    /// </summary>
    public IReadOnlyDictionary<CharacterData, int> GetAllAffinities()
    {
        return affinityMap;
    }
}
