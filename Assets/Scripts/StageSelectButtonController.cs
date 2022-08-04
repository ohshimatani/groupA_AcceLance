using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButtonController : MonoBehaviour
{
    /// <summary>
    /// クリックされたボタンに応じてStageMode（Enum）の値をセットする
    /// </summary>
    public void OnClick()
    {
        // �ｿｽ�ｿｽ�ｿｽg�ｿｽﾌオ�ｿｽu�ｿｽW�ｿｽF�ｿｽN�ｿｽg�ｿｽ�ｿｽ
        string buttonName = gameObject.name;

        GameObject obj = GameObject.Find("StageSelectManager");
        StageSelectManager stageSelectManager = obj.GetComponent<StageSelectManager>();
        
        // �ｿｽ�ｿｽ�ｿｽw1�ｿｽN�ｿｽ�ｿｽ�ｿｽﾌ奇ｿｽ�ｿｽ�ｿｽ�ｿｽX�ｿｽe�ｿｽ[�ｿｽW�ｿｽ�ｿｽ�ｿｽI�ｿｽ�ｿｽ�ｿｽ�ｿｽ�ｿｽ黷ｽ�ｿｽﾆゑｿｽ
        if ("FirstGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.FIRST;
            return;
        }

        // �ｿｽ�ｿｽ�ｿｽw2�ｿｽN�ｿｽ�ｿｽ�ｿｽﾌ奇ｿｽ�ｿｽ�ｿｽ�ｿｽX�ｿｽe�ｿｽ[�ｿｽW�ｿｽ�ｿｽ�ｿｽI�ｿｽ�ｿｽ�ｿｽ�ｿｽ�ｿｽ黷ｽ�ｿｽﾆゑｿｽ
        if ("SecondGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.SECOND;
            return;
        }

        // �ｿｽ�ｿｽ�ｿｽw1�ｿｽN�ｿｽ�ｿｽ&2�ｿｽN�ｿｽ�ｿｽ�ｿｽﾌ奇ｿｽ�ｿｽ�ｿｽ�ｿｽX�ｿｽe�ｿｽ[�ｿｽW�ｿｽ�ｿｽ�ｿｽI�ｿｽ�ｿｽ�ｿｽ�ｿｽ�ｿｽ黷ｽ�ｿｽﾆゑｿｽ
        if ("AllGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.ALL;
            return;
        }
    }
}
