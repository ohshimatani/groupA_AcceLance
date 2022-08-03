using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

    /// <summary>
    /// ����ʂɁA�����Ƃ��ė^����ꂽ�����̏��𔽉f
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void DisplayKanji(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // �e��l�𔽉f
        GameObject.Find("TitleKanji").GetComponent<Text>().text = this.kanjiInfo.kanji;
        GameObject.Find("OnyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.onyomi);
        GameObject.Find("KunyomiText").GetComponent<Text>().text = string.Join(", ", this.kanjiInfo.kunyomi);
        GameObject.Find("NumberOfStroekText").GetComponent<Text>().text = this.kanjiInfo.kakusu.ToString();
        GameObject.Find("DefeatNumberText").GetComponent<Text>().text = this.kanjiInfo.defeat_count.ToString();
    }

    /// <summary>
    /// ����ʂɁH�𔽉f
    /// �u�����������v����"0"��
    /// </summary>
    public void DisplayHatena(KanjiInfo kanjiInfo)
    {
        // �n�e�i�}�[�N
        const string HATENA = "�H";

        // �e��l�𔽉f
        GameObject.Find("TitleKanji").GetComponent<Text>().text = HATENA;
        GameObject.Find("OnyomiText").GetComponent<Text>().text = HATENA;
        GameObject.Find("KunyomiText").GetComponent<Text>().text = HATENA;
        GameObject.Find("NumberOfStroekText").GetComponent<Text>().text = HATENA;
        GameObject.Find("DefeatNumberText").GetComponent<Text>().text = kanjiInfo.defeat_count.ToString();
    }

}
