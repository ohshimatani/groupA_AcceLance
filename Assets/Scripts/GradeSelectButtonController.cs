using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeSelectButtonController : MonoBehaviour
{
    // ���߂ɑI����Ԃɂ���{�^��
    [SerializeField] GameObject startSelectedButton;

    // ���ݑI����Ԃɂ���{�^��
    private GameObject currentSelectedButton;

    private void Start()
    {
        // �I����Ԃ̉摜���Z�b�g����
        startSelectedButton.GetComponent<GradeSelectButton>().SetSpriteIsSelect();
        currentSelectedButton = startSelectedButton;
    }

    /// <summary>
    /// ���ݑI����Ԃɂ���{�^���̉摜��ύX����
    /// </summary>
    /// <param name="obj"></param>
    public void ChangeSelectedButton(GameObject obj)
    {
        if (currentSelectedButton == obj)
        {
            return;
        }

        // ���ݑI����Ԃɂ���{�^�����I����Ԃɂ���
        currentSelectedButton.GetComponent<GradeSelectButton>().SetSpriteNotIsSelect();

        // �V���ɑI�����ꂽ�{�^����I����ԉ摜�ɕύX���AcurrentSelectedButton���X�V����
        obj.GetComponent<GradeSelectButton>().SetSpriteIsSelect();
        currentSelectedButton = obj;
    }
}
