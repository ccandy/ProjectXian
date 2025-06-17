using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 管理游戏世界地图的数据，包括各个地点的配置和当前玩家位置。
/// 使用 MapConfigSO 来配置各地图点信息。
/// </summary>
public class MapSystem : MonoBehaviour
{
    public static MapSystem Instance { get; private set; }

    [Tooltip("所有地图点的配置SO列表")]
    public List<MapConfigSO> mapPoints;

    // 当前地图点索引
    public int currentMapIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    /// <summary>
    /// 获取当前地图点配置。
    /// </summary>
    public MapConfigSO GetCurrentMapPoint()
    {
        if (mapPoints == null || mapPoints.Count == 0)
            return null;
        currentMapIndex = Mathf.Clamp(currentMapIndex, 0, mapPoints.Count - 1);
        return mapPoints[currentMapIndex];
    }

    /// <summary>
    /// 切换到下一个地图点。
    /// </summary>
    public void NextMapPoint()
    {
        if (mapPoints == null || mapPoints.Count == 0) return;
        currentMapIndex = (currentMapIndex + 1) % mapPoints.Count;
    }

    /// <summary>
    /// 切换到上一个地图点。
    /// </summary>
    public void PreviousMapPoint()
    {
        if (mapPoints == null || mapPoints.Count == 0) return;
        currentMapIndex = (currentMapIndex - 1 + mapPoints.Count) % mapPoints.Count;
    }
}