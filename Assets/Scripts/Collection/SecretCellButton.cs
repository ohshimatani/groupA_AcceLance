using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCellButton : AbstractCellButton
{
    /// <summary>
    /// 漢字セルの漢字の情報を初期化し、セル内のテキストに反映する
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public override void InitStatus(KanjiInfo kanjiInfo)
    {
        Debug.Log("aaa");
        this.kanjiInfo = kanjiInfo;
    }
}
