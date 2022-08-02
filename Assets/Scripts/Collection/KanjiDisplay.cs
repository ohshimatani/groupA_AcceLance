using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // 漢字の情報（読み取り専用）
    public KanjiInfo kanjiInfo { get; private set; }

    /// <summary>
    /// 引数に与えられた漢字の情報を反映
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void Display(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // 各種値を反映
        GameObject.Find("TitleKanji").GetComponent<Text>().text = this.kanjiInfo.kanji;
        GameObject.Find("OnyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.onyomi);
        GameObject.Find("KunyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.kunyomi);
        GameObject.Find("NumberOfStroekText").GetComponent<Text>().text = this.kanjiInfo.kakusu.ToString();
        GameObject.Find("DefeatNumberText").GetComponent<Text>().text = this.kanjiInfo.defeat_count.ToString();
    }

}
