using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理角色的好感度点数，值在 minAffection 到 maxAffection 范围内。
/// 当好感度变化时触发事件通知。
/// </summary>
public class AffectionManager : SingletonMonoBehaviour<AffectionManager>
{
   private Dictionary<string ,int> affectionDictionary = new Dictionary<string ,int>();
   private const int minAffection = 0;
   private const int maxAffection = 100;

   private void ModifyAffection(string affectionKey, int affectionValue)
   {
      if (!affectionDictionary.ContainsKey(affectionKey))
      {
         affectionDictionary[affectionKey] = 0;
      }

      int increaseValue = affectionDictionary[affectionKey] + affectionValue;
      int newValue = Mathf.Clamp(increaseValue, minAffection, maxAffection);
      AffectionEventData data = new AffectionEventData(affectionKey, newValue);
      EventManager.Instance.TriggerEvent("OnAffectionChanged", data);
   }

   public int GetAffectionValue(string affectionKey)
   {
      return affectionDictionary.ContainsKey(affectionKey) ? affectionDictionary[affectionKey] : 0;
   }
   
   public Dictionary<string,int> GetAllAffection() => new Dictionary<string,int>(affectionDictionary);

   public void SetAffection(string characterName, int value)
   {
      affectionDictionary[characterName] = Mathf.Clamp(value, minAffection, maxAffection);
   }
   
}

public struct AffectionEventData
{
   public string CharacterName;
   public int NewValue;

   public AffectionEventData(string characterName, int newValue)
   {
      CharacterName = characterName;
      NewValue = newValue;
   }
}
