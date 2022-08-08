using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    /// <summary>
    /// クリックされたボタンに応じてStageMode（Enum）の値をセットする
    /// </summary>
    public void OnClick()
    {
        // クリックされたボタンオブジェクトの名前
        string buttonName = gameObject.name;

        GameObject obj = GameObject.Find("StageSelectManager");
        StageSelectManager stageSelectManager = obj.GetComponent<StageSelectManager>();
        
        // 小学1年生が選択されたとき
        if ("FirstGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.FIRST;
            return;
        }

        // 小学2年生が選択されたとき
        if ("SecondGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.SECOND;
            return;
        }

        // 小学1年生&2年生が選択されたとき
        if ("AllGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.ALL;
            return;
        }
    }
}
