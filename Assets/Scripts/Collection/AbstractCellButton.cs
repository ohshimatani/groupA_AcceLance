using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCellButton : MonoBehaviour
{
    // 漢字の情報
    protected KanjiInfo kanjiInfo { get; set; }

    /// <summary>
    /// 漢字かシークレットかによって、内部の処理を変える
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public abstract void InitStatus(KanjiInfo kanjiInfo);

    /// <summary>
    /// ディスプレイに表示するために、漢字をセットする
    /// </summary>
    public void OnClickShowDisplay()
    {
        GameObject leftContainer = GameObject.Find("LeftContainer");
        leftContainer.GetComponent<KanjiDisplay>().DisplayHatena(kanjiInfo);
    }
}
