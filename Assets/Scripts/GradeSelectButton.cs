using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GradeSelectButton : MonoBehaviour
{
    // �I���E��I���̂Ƃ��̉摜
    [SerializeField] Sprite isSelect;
    [SerializeField] Sprite notIsSelect;

    // OnClick���\�b�h����GetComponent����ۂɎg�p����
    [SerializeField] GameObject gradeSelectButtonControllerObj;
    [SerializeField] GameObject scrollViewControllerObj;

    /// <summary>
    /// GradeSelectButtonController�ɃN���b�N�����{�^���I�u�W�F�N�g��n��
    /// </summary>
    public void OnClick()
    {
        gradeSelectButtonControllerObj.GetComponent<GradeSelectButtonController>().ChangeSelectedButton(gameObject);

        // �{�^�����ɉ����āAGradeType���擾���ADeployCellButton���\�b�h�ɓn��
        GradeType gradeType = GetGradeTypeByGameObjectName(gameObject.name);
        scrollViewControllerObj.GetComponent<ScrollViewController>().DeployCellButton(gradeType);
    }

    /// <summary>
    /// GameObject�̖��O�ɉ����āAGradeType���擾����
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
                throw new Exception("�Y������v�f������܂���");
        }
    }

    /// <summary>
    /// �I����Ԃ̉摜�ɐ؂�ւ���
    /// </summary>
    public void SetSpriteIsSelect()
    {
        gameObject.GetComponent<Image>().sprite = isSelect;
    }
    /// <summary>
    /// ��I����Ԃ̉摜�ɐ؂�ւ���
    /// </summary>
    public void SetSpriteNotIsSelect()
    {
        gameObject.GetComponent<Image>().sprite = notIsSelect;
    }
}
