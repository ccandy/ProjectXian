using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 好感面板脚本：显示当前角色的头像、姓名与好感度
/// </summary>
public class AffinityUI : MonoBehaviour
{
    [Header("角色头像")]
    public Image portraitImage;
    [Header("角色名称")]
    public Text nameText;
    [Header("好感度滑动条")]
    public Slider affinitySlider;
    [Header("好感度数值")]
    public Text affinityValueText;

    /// <summary>
    /// 设置并更新面板上的角色信息与好感度
    /// </summary>
    /// <param name="character">角色数据</param>
    /// <param name="value">当前好感度（0–100）</param>
    public void SetAffinity(CharacterData character, int value)
    {
        if (character != null)
        {
            portraitImage.sprite = character.portrait;
            nameText.text = character.characterName;
        }
        else
        {
            portraitImage.sprite = null;
            nameText.text = string.Empty;
        }

        if (affinitySlider != null)
        {
            affinitySlider.maxValue = 100;
            affinitySlider.value = value;
        }

        if (affinityValueText != null)
        {
            affinityValueText.text = $"{value}/100";
        }
    }
}