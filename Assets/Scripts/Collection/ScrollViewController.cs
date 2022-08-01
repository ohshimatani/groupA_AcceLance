using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // Content���A�^�b�`
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCell��Prefab��ݒ�
    [SerializeField] GameObject kanjiCellPrefab;

    // SecretCell��Prefab��ݒ�
    [SerializeField] GameObject secretCellPrefab;


    /// <summary>
    /// �����f�[�^��JSON�t�@�C������擾���A���ꂼ��{�^����Text�ɔ��f����B
    /// </summary>
    private void Start()
    {
        // �����f�[�^��JSON�t�@�C������擾
        JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
        KanjiInfo[] kanjiInfoArray = jsonManager.GetKanjiInfoByStageMode(StageMode.ALL);

        // �����ɓn���������̏������ƂɁA�����̃Z�� or �n�e�i�̃Z����z�u
        DisposeKanjiCell(kanjiInfoArray);
    }


    /// <summary>
    /// �����̏������ƂɁA�����̃Z�� or �n�e�i�̃Z����z�u����B
    /// </summary>
    /// <param name="kanjiInfoArray"></param>
    private void DisposeKanjiCell(KanjiInfo[] kanjiInfoArray)
    {
        // �擾���������̐�����KanjiCell�𐶐����AScrollView����Grid�z�u
        for (int i = 0; i < kanjiInfoArray.Length; i++)
        {
            if (kanjiInfoArray[i].defeat_count >= 1)
            {
                // �|���ꂽ�����P���傫���Ƃ��A���̊���Cell��\��
                GameObject kanjiCell = Instantiate(kanjiCellPrefab, contentRectTransform);
                kanjiCell.GetComponent<KanjiCell>().InitKanjiStatus(kanjiInfoArray[i]);

                // [TODO]
                // kanjiCell.GetComponentInChildren<Text>().text = kanjiInfoArray[i].kanji;
                // kanjiCell.GetComponent<KanjiCell>().kanjiInfo = kanjiInfoArray[i];

            } else
            {
                // �|����Ă��Ȃ������̂Ƃ��A�n�e�i��\��
                Instantiate(secretCellPrefab, contentRectTransform);
            }
        }
    }
}
