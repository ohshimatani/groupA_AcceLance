using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectButton : MonoBehaviour
{
    /// <summary>
    /// �N���b�N���ꂽ�{�^���ɉ�����StageMode�iEnum�j�̒l���Z�b�g����
    /// </summary>
    public void OnClick()
    {
        // �N���b�N���ꂽ�{�^���I�u�W�F�N�g�̖��O
        string buttonName = gameObject.name;

        GameObject obj = GameObject.Find("StageSelectManager");
        StageSelectManager stageSelectManager = obj.GetComponent<StageSelectManager>();
        
        // ���w1�N�����I�����ꂽ�Ƃ�
        if ("FirstGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.FIRST;
            return;
        }

        // ���w2�N�����I�����ꂽ�Ƃ�
        if ("SecondGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.SECOND;
            return;
        }

        // ���w1�N��&2�N�����I�����ꂽ�Ƃ�
        if ("AllGradeButton".Equals(buttonName))
        {
            StageSelectManager.gradeType = GradeType.ALL;
            return;
        }
    }
}
