using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCell : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

    public void InitKanjiStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
    }
}
