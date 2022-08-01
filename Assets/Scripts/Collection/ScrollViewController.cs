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
        JsonManager jsonManager = new JsonManager();
        Debug.Log(StageMode.ALL);
        KanjiInfo[] kanjiInfo = jsonManager.GetKanjiInfoByStageMode(StageMode.ALL);

        Debug.Log(kanjiInfo.Length);
        // �����ɓn���������̏������ƂɁA�����̃Z�� or �n�e�i�̃Z����z�u
        DisposeKanjiCell(kanjiInfo);
    }

    /// <summary>
    /// �����̏������ƂɁA�����̃Z�� or �n�e�i�̃Z����z�u����B
    /// </summary>
    /// <param name="kanjiInfo"></param>
    private void DisposeKanjiCell(KanjiInfo[] kanjiInfo)
    {
        // �擾���������̐�����KanjiCell�𐶐����AScrollView����Grid�z�u
        for (int i = 0; i < kanjiInfo.Length; i++)
        {
            if (kanjiInfo[i].defeat_count >= 1)
            {
                // �|���ꂽ�����P���傫���Ƃ��A���̊���Cell��\��
                GameObject kanjiCell = Instantiate(kanjiCellPrefab, contentRectTransform);
                kanjiCell.GetComponentInChildren<Text>().text = kanjiInfo[i].kanji;
            } else
            {
                // �|����Ă��Ȃ������̂Ƃ��A�n�e�i��\��
                Instantiate(secretCellPrefab, contentRectTransform);
            }
        }
    }
}
