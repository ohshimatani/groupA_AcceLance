using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiDisplay : MonoBehaviour
{
    // �����̏��i�ǂݎ���p�j
    public KanjiInfo kanjiInfo { get; private set; }

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
    public void DisplayKanji(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // �e��l�𔽉f
        titleText.text = this.kanjiInfo.kanji;
        onyomiText.text = string.Join(", ", this.kanjiInfo.onyomi);
        kunyomiText.text = string.Join(", ", this.kanjiInfo.kunyomi);
        numberOfStrokeText.text = this.kanjiInfo.kakusu.ToString();
        defeatNumberText.text = this.kanjiInfo.defeat_count.ToString();
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
