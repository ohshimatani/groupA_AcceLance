using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButtonController : MonoBehaviour
{
    /// <summary>
    /// ƒNƒŠƒbƒN‚³‚ê‚½ƒ{ƒ^ƒ“‚É‰‚¶‚ÄStageModeiEnumj‚Ì’l‚ğƒZƒbƒg‚·‚é
    /// </summary>
    public void OnClick()
    {
        // ï¿½ï¿½ï¿½gï¿½ÌƒIï¿½uï¿½Wï¿½Fï¿½Nï¿½gï¿½ï¿½
        string buttonName = gameObject.name;

        GameObject obj = GameObject.Find("StageSelectManager");
        StageSelectManager stageSelectManager = obj.GetComponent<StageSelectManager>();
        
        // ï¿½ï¿½ï¿½w1ï¿½Nï¿½ï¿½ï¿½ÌŠï¿½ï¿½ï¿½ï¿½Xï¿½eï¿½[ï¿½Wï¿½ï¿½ï¿½Iï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½Æ‚ï¿½
        if ("FirstGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.FIRST;
            return;
        }

        // ï¿½ï¿½ï¿½w2ï¿½Nï¿½ï¿½ï¿½ÌŠï¿½ï¿½ï¿½ï¿½Xï¿½eï¿½[ï¿½Wï¿½ï¿½ï¿½Iï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½Æ‚ï¿½
        if ("SecondGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.SECOND;
            return;
        }

        // ï¿½ï¿½ï¿½w1ï¿½Nï¿½ï¿½&2ï¿½Nï¿½ï¿½ï¿½ÌŠï¿½ï¿½ï¿½ï¿½Xï¿½eï¿½[ï¿½Wï¿½ï¿½ï¿½Iï¿½ï¿½ï¿½ï¿½ï¿½ê‚½ï¿½Æ‚ï¿½
        if ("AllGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.ALL;
            return;
        }
    }
}
