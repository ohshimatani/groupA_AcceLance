using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCellButton : AbstractCellButton
{
    /// <summary>
    /// �����Z���̊����̏������������A�Z�����̃e�L�X�g�ɔ��f����
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public override void InitStatus(KanjiInfo kanjiInfo)
    {
        Debug.Log("aaa");
        this.kanjiInfo = kanjiInfo;
    }
}
