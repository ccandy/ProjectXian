// SaveLoadManager.cs
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class SaveData
{
    public string date;
    public SerializableDictionary<string, int> affection;
}

/// <summary>
/// 存档系统，负责保存和加载游戏状态。
/// </summary>
public class SaveLoadManager : SingletonMonoBehaviour<SaveLoadManager>
{
    private string saveFilePath;

    protected override void Awake()
    {
        base.Awake();
        saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    public void SaveGame()
    {
        SaveData data = new SaveData
        {
            date = DateSystem.Instance.GetDateString(),
            affection = new SerializableDictionary<string, int>(AffectionManager.Instance.GetAllAffection())
        };
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log($"存档已保存：{saveFilePath}");
    }

    public void LoadGame()
    {
        if (!File.Exists(saveFilePath)) { Debug.LogWarning("未找到存档"); return; }
        string json = File.ReadAllText(saveFilePath);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        if (DateTime.TryParse(data.date, out DateTime dt))
            DateSystem.Instance.SetDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute);
        foreach (var kv in data.affection)
            AffectionManager.Instance.SetAffection(kv.Key, kv.Value);
        EventManager.Instance.TriggerEvent("OnGameLoaded", data);
        Debug.Log("存档已加载");
    }
}