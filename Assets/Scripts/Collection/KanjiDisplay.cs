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
        GameObject.Find("TitleKanji").GetComponent<Text>().text = this.kanjiInfo.kanji;
        GameObject.Find("OnyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.onyomi);
        GameObject.Find("KunyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.kunyomi);
        GameObject.Find("NumberOfStroekText").GetComponent<Text>().text = this.kanjiInfo.kakusu.ToString();
        GameObject.Find("DefeatNumberText").GetComponent<Text>().text = this.kanjiInfo.defeat_count.ToString();
    }

}
