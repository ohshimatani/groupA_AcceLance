using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCell : MonoBehaviour
{
    // 漢字の情報（読み取り専用）
    public KanjiInfo kanjiInfo { get; private set; }

    public void InitKanjiStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
    }
}
