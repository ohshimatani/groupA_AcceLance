using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeSelectButton : MonoBehaviour
{
    // 選択・非選択のときの画像
    [SerializeField] Sprite isSelect;
    [SerializeField] Sprite notIsSelect;

    /// <summary>
    /// GradeSelectButtonControllerにクリックしたボタンオブジェクトを渡す
    /// </summary>
    public void OnClick()
    {
        GameObject obj = GameObject.Find("GradeSelectButtonController");
        obj.GetComponent<GradeSelectButtonController>().ChangeSelectedButton(gameObject);
    }

    /// <summary>
    /// 選択状態の画像に切り替える
    /// </summary>
    public void SetSpriteIsSelect()
    {
        gameObject.GetComponent<Image>().sprite = isSelect;
    }
    /// <summary>
    /// 非選択状態の画像に切り替える
    /// </summary>
    public void SetSpriteNotIsSelect()
    {
        gameObject.GetComponent<Image>().sprite = notIsSelect;
    }
}
