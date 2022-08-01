using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiCell : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

    /// <summary>
    /// �����Z���̊����̏������������A�Z�����̃e�L�X�g�ɔ��f����
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void InitKanjiStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
    }
}
