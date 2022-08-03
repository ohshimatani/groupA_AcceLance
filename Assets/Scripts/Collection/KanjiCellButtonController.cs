using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiCellButtonController : MonoBehaviour
{
    /// <summary>
    /// �N���b�N���ꂽ�Ƃ��ɔ������郁�\�b�h�B
    /// �����̏����󂯎��A����ʂɔ��f������
    /// </summary>
    public void OnClickShowDisplay()
    {
        // �Z�����犿���̏�������
        KanjiInfo kanjiInfo = gameObject.GetComponent<KanjiCell>().kanjiInfo;

        // ���̃R���e�i�ɃA�^�b�`����Ă���KanjiDisplay��get���A�l�𔽉f������֐����Ă�
        GameObject.Find("LeftContainer").GetComponent<KanjiDisplay>().DisplayKanji(kanjiInfo);
    }
}
