/* --------------------------------------------------------------------------
   ActionMenuUI.cs
   可选动作菜单脚本：动态生成按钮供玩家选择动作
   -------------------------------------------------------------------------- */
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenuUI : MonoBehaviour
{
    [Header("动作按钮预制")] public GameObject buttonPrefab; // 包含 Text 和 Button 组件
    [Header("按钮父物体")] public Transform buttonsParent;

    private Action<string> onActionSelected;

    /// <summary>
    /// 显示动作列表，并绑定回调
    /// </summary>
    public void ShowActions(List<string> actions, Action<string> callback)
    {
        // 清空原有按钮
        foreach (Transform child in buttonsParent)
        {
            Destroy(child.gameObject);
        }

        onActionSelected = callback;
        gameObject.SetActive(true);

        // 创建新按钮
        foreach (var actionName in actions)
        {
            var go = Instantiate(buttonPrefab, buttonsParent);
            var text = go.GetComponentInChildren<Text>();
            var button = go.GetComponent<Button>();
            if (text != null) text.text = actionName;
            if (button != null)
            {
                string a = actionName;
                button.onClick.AddListener(() => OnButtonClicked(a));
            }
        }
    }

    private void OnButtonClicked(string actionName)
    {
        gameObject.SetActive(false);
        onActionSelected?.Invoke(actionName);
    }
}