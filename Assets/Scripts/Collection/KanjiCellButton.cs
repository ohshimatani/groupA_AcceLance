using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiCellButton : AbstractCellButton
{
    /// <summary>
    /// 漢字セルの漢字の情報を初期化し、セル内のテキストに反映する
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public override void InitStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
    }
}
