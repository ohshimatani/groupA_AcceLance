using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCellButtonController : MonoBehaviour
{
    /// <summary>
    /// �N���b�N���ꂽ�Ƃ��ɔ������郁�\�b�h�B
    /// ����ʂɃn�e�i�𔽉f������B
    /// </summary>
    public void OnClickShowDisplay()
    {
        // �Z�����犿���̏�������
        KanjiInfo kanjiInfo = gameObject.GetComponent<SecretCell>().kanjiInfo;

        // ���̃R���e�i�ɃA�^�b�`����Ă���KanjiDisplay��get���A�l�𔽉f������֐����Ă�
        GameObject.Find("LeftContainer").GetComponent<KanjiDisplay>().DisplayHatena(kanjiInfo);
    }
}
