using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

    private const string HATENA = "?";

    // �e��Z�b�g����p��Text
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
    /// ����ʂɁA�����Ƃ��ė^����ꂽ�����̏��𔽉f
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
