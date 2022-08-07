using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GradeSelectButton : MonoBehaviour
{
    // 選択・非選択のときの画像
    [SerializeField] Sprite isSelect;
    [SerializeField] Sprite notIsSelect;

    // OnClickメソッド内でGetComponentする際に使用する
    [SerializeField] GameObject gradeSelectButtonControllerObj;
    [SerializeField] GameObject scrollViewControllerObj;

    /// <summary>
    /// GradeSelectButtonControllerにクリックしたボタンオブジェクトを渡す
    /// </summary>
    public void OnClick()
    {
        gradeSelectButtonControllerObj.GetComponent<GradeSelectButtonController>().ChangeSelectedButton(gameObject);

        // ボタン名に応じて、GradeTypeを取得し、DeployCellButtonメソッドに渡す
        GradeType gradeType = GetGradeTypeByGameObjectName(gameObject.name);
        scrollViewControllerObj.GetComponent<ScrollViewController>().DeployCellButton(gradeType);
    }

    /// <summary>
    /// GameObjectの名前に応じて、GradeTypeを取得する
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private GradeType GetGradeTypeByGameObjectName(string objName)
    {
        switch(objName)
        {
            case "AllSelectButton":
                return GradeType.ALL;
            case "1GradeButton":
                return GradeType.FIRST;
            case "2GradeButton":
                return GradeType.SECOND;
            default:
                throw new Exception("該当する要素がありません");
        }
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
