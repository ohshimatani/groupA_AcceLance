using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiCell : MonoBehaviour
{
    // 漢字の情報（読み取り専用）
    public KanjiInfo kanjiInfo { get; private set; }

    /// <summary>
    /// 漢字セルの漢字の情報を初期化し、セル内のテキストに反映する
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void InitKanjiStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
    }
}
