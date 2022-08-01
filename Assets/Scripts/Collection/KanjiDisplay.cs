using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

    /// <summary>
    /// �����ɗ^����ꂽ�����̏��𔽉f
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void Display(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // �e��l�𔽉f
        GameObject.Find("TitleKanji").GetComponent<Text>().text = kanjiInfo.kanji;
        GameObject.Find("OnyomiText").GetComponent<Text>().text = string.Join(", ", kanjiInfo.onyomi);
        GameObject.Find("KunyomiText").GetComponent<Text>().text = string.Join(", ", kanjiInfo.kunyomi);
        GameObject.Find("NumberOfStroekText").GetComponent<Text>().text = kanjiInfo.kakusu.ToString();
        GameObject.Find("DefeatNumberText").GetComponent<Text>().text = kanjiInfo.defeat_count.ToString();
    }

}
