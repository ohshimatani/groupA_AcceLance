using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCellButton : MonoBehaviour
{
    // 漢字の情報
    private KanjiInfo kanjiInfo { get; set; }

    /// <summary>
    /// 漢字かシークレットかによって、内部の処理を変える
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void InitStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // KanjiCellButtonの時はテキストのセットも行う
        if (gameObject.name.Contains("KanjiCellButton"))
        {
            gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
        }
    }

    /// <summary>
    /// ディスプレイに表示するために、漢字をセットする
    /// </summary>
    public void OnClickShowDisplay()
    {
        GameObject leftContainer = GameObject.Find("LeftContainer");
        leftContainer.GetComponent<KanjiDisplay>().DisplayByKanjiInfo(kanjiInfo);
    }
}
