using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiCellButton : AbstractCellButton
{
    /// <summary>
    /// �����Z���̊����̏������������A�Z�����̃e�L�X�g�ɔ��f����
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public override void InitStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
    }
}
