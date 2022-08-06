using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GradeSelectButton : MonoBehaviour
{
    // �I���E��I���̂Ƃ��̉摜
    [SerializeField] Sprite isSelect;
    [SerializeField] Sprite notIsSelect;

    /// <summary>
    /// GradeSelectButtonController�ɃN���b�N�����{�^���I�u�W�F�N�g��n��
    /// </summary>
    public void OnClick()
    {
        GameObject obj = GameObject.Find("GradeSelectButtonController");
        obj.GetComponent<GradeSelectButtonController>().ChangeSelectedButton(gameObject);
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
