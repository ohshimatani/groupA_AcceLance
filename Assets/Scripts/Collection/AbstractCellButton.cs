using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCellButton : MonoBehaviour
{
    // �����̏��
    protected KanjiInfo kanjiInfo { get; set; }

    /// <summary>
    /// �������V�[�N���b�g���ɂ���āA�����̏�����ς���
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public abstract void InitStatus(KanjiInfo kanjiInfo);

    /// <summary>
    /// �f�B�X�v���C�ɕ\�����邽�߂ɁA�������Z�b�g����
    /// </summary>
    public void OnClickShowDisplay()
    {
        GameObject leftContainer = GameObject.Find("LeftContainer");
        leftContainer.GetComponent<KanjiDisplay>().DisplayHatena(kanjiInfo);
    }
}
