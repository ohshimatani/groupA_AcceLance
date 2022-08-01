using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // Content���A�^�b�`
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCell��Prefab��ݒ�
    [SerializeField] GameObject buttonCell;

    /// <summary>
    /// �����f�[�^��JSON�t�@�C������擾���A���ꂼ��{�^����Text�ɔ��f����B
    /// </summary>
    private void Start()
    {
        // �����f�[�^��JSON�t�@�C������擾
        JsonManager jsonManager = new JsonManager();
        KanjiInfo[] kanjiInfo = jsonManager.ReadJsonData();

        for (int i = 0; i < kanjiInfo.Length; i++)
        {
            GameObject kanjiCell = Instantiate(buttonCell, contentRectTransform);
            kanjiCell.GetComponentInChildren<Text>().text = kanjiInfo[i].kanji;
        }
    }
}
