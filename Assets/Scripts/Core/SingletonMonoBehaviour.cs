using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通用单例基类，其他 MonoBehaviour 类可继承以获取单例功能。
/// </summary>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    
    private static T _instance;
    private static object _lockObj = new object();

    /// <summary>
    /// 全局唯一实例，若尚未初始化则查找场景中的对象；若仍为 null，则创建并保留。
    /// </summary>
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();
                        if (_instance == null)
                        {
                            var go = new GameObject(typeof(T).Name);
                            _instance = go.AddComponent<T>();
                            DontDestroyOnLoad(go);
                        }
                    }
                }
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}
