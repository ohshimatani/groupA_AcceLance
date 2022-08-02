using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCellButtonController : MonoBehaviour
{
    /// <summary>
    /// クリックされたときに発動するメソッド。
    /// 左画面にハテナを反映させる。
    /// </summary>
    public void OnClickShowDisplay()
    {
        // セルから漢字の情報を所得
        KanjiInfo kanjiInfo = gameObject.GetComponent<SecretCell>().kanjiInfo;

        // 左のコンテナにアタッチされているKanjiDisplayをgetし、値を反映させる関数を呼ぶ
        GameObject.Find("LeftContainer").GetComponent<KanjiDisplay>().DisplayHatena(kanjiInfo);
    }
}
