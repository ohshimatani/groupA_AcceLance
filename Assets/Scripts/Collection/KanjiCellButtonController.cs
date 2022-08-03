using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiCellButtonController : MonoBehaviour
{
    /// <summary>
    /// クリックされたときに発動するメソッド。
    /// 漢字の情報を受け取り、左画面に反映させる
    /// </summary>
    public void OnClickShowDisplay()
    {
        // セルから漢字の情報を所得
        KanjiInfo kanjiInfo = gameObject.GetComponent<KanjiCell>().kanjiInfo;

        // 左のコンテナにアタッチされているKanjiDisplayをgetし、値を反映させる関数を呼ぶ
        GameObject.Find("LeftContainer").GetComponent<KanjiDisplay>().DisplayKanji(kanjiInfo);
    }
}
