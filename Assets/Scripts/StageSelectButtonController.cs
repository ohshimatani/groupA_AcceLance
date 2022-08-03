using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButtonController : MonoBehaviour
{
    public void OnClick()
    {
        // 自身のオブジェクト名
        string buttonName = gameObject.name;

        GameObject obj = GameObject.Find("StageSelectManager");
        StageSelectManager stageSelectManager = obj.GetComponent<StageSelectManager>();
        
        // 小学1年生の漢字ステージが選択されたとき
        if ("FirstGradeButton".Equals(buttonName))
        {
            StageSelectManager.stageMode = StageMode.GAKUNEN_1;
            return;
        }

        // 小学2年生の漢字ステージが選択されたとき
        if ("SecondGradeButton".Equals(buttonName))
        {
            StageSelectManager.stageMode = StageMode.GAKUNEN_2;
            return;
        }

        // 小学1年生&2年生の漢字ステージが選択されたとき
        if ("AllGradeButton".Equals(buttonName))
        {
            StageSelectManager.stageMode = StageMode.ALL;
            return;
        }
    }
}
