// SerializableDictionary.cs
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 使字典可被 JsonUtility 序列化。
/// </summary>
[Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();

    public SerializableDictionary() { }
    public SerializableDictionary(Dictionary<TKey, TValue> dict) : base(dict) { }

    /// <summary>
    /// 序列化前，将字典内容填充到列表中。
    /// </summary>
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (var kv in this)
        {
            keys.Add(kv.Key);
            values.Add(kv.Value);
        }
    }

    /// <summary>
    /// 反序列化后，将列表内容重新填充到字典中。
    /// </summary>
    public void OnAfterDeserialize()
    {
        Clear();
        int count = Math.Min(keys.Count, values.Count);
        for (int i = 0; i < count; i++)
        {
            this[keys[i]] = values[i];
        }
    }
}