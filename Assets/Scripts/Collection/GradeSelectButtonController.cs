using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeSelectButtonController : MonoBehaviour
{
    // 初めに選択状態にするボタン
    [SerializeField] GameObject startSelectedButton;

    // 現在選択状態にあるボタン
    private GameObject currentSelectedButton;

    private void Start()
    {
        // 選択状態の画像をセットする
        startSelectedButton.GetComponent<GradeSelectButton>().SetSpriteIsSelect();
        currentSelectedButton = startSelectedButton;
    }

    /// <summary>
    /// 現在選択状態にあるボタンの画像を変更する
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeSelectedButton(GameObject obj)
    {
        if (currentSelectedButton == obj)
        {
            return;
        }

        // 現在選択状態にあるボタンを非選択状態にする
        currentSelectedButton.GetComponent<GradeSelectButton>().SetSpriteNotIsSelect();

        // 新たに選択されたボタンを選択状態画像に変更し、currentSelectedButtonを更新する
        obj.GetComponent<GradeSelectButton>().SetSpriteIsSelect();
        currentSelectedButton = obj;
    }
}
