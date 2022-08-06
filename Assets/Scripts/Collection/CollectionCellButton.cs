using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionCellButton : MonoBehaviour
{
    // �����̏��
    private KanjiInfo kanjiInfo { get; set; }

    /// <summary>
    /// �������V�[�N���b�g���ɂ���āA�����̏�����ς���
    /// </summary>
    /// <param name="kanjiInfo"></param>
    public void InitStatus(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;

        // KanjiCellButton�̎��̓e�L�X�g�̃Z�b�g���s��
        if (gameObject.name.Contains("KanjiCellButton"))
        {
            gameObject.GetComponentInChildren<Text>().text = kanjiInfo.kanji;
        }
    }

    /// <summary>
    /// �f�B�X�v���C�ɕ\�����邽�߂ɁA�������Z�b�g����
    /// </summary>
    public void OnClickShowDisplay()
    {
        GameObject leftContainer = GameObject.Find("LeftContainer");
        leftContainer.GetComponent<KanjiDisplay>().DisplayByKanjiInfo(kanjiInfo);
    }
}
