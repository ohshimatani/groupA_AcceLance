using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // 漢字の情報（読み取り専用）
    public KanjiInfo kanjiInfo { get; private set; }

    private const string HATENA = "?";

    // 各種セットする用のText
    private Text titleText;
    private Text onyomiText;
    private Text kunyomiText;
    private Text numberOfStrokeText;
    private Text defeatNumberText;

    private void Start()
    {
        titleText = GameObject.Find("TitleKanji").GetComponent<Text>();
        onyomiText = GameObject.Find("OnyomiText").GetComponent<Text>();
        kunyomiText = GameObject.Find("KunyomiText").GetComponent<Text>();
        numberOfStrokeText = GameObject.Find("NumberOfStrokeText").GetComponent<Text>();
        defeatNumberText = GameObject.Find("DefeatNumberText").GetComponent<Text>();
    }

    /// <summary>
    /// 左画面に、引数として与えられた漢字の情報を反映
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void DisplayByKanjiInfo(KanjiInfo kanjiInfo)
    {
        if (kanjiInfo.defeat_count > 0)
        {
            titleText.text = kanjiInfo.kanji;
            onyomiText.text = string.Join(", ", kanjiInfo.onyomi);
            kunyomiText.text = string.Join(", ", kanjiInfo.kunyomi);
            numberOfStrokeText.text = kanjiInfo.kakusu.ToString();
            defeatNumberText.text = kanjiInfo.defeat_count.ToString();
        }
        else
        {
            titleText.text = HATENA;
            onyomiText.text = HATENA;
            kunyomiText.text = HATENA;
            numberOfStrokeText.text = HATENA;
            defeatNumberText.text = "0";
        }
    }
}
