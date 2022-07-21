using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData
{
    public KanjiInfo[] kanjiInfos;
}

[System.Serializable]
public class KanjiInfo
{
    // ����
    public string kanji;

    // ���ǂ݂̃��X�g
    public string[] onyomi;

    // �P�ǂ݂̃��X�g
    public string[] kunyomi;

    // �����̉搔
    public int kakusu;
}

public class JsonReader : MonoBehaviour
{
    /// <summary>
    /// KanjiInfos.json��ǂݍ��݁AKanjiInfo�N���X�z��Ƃ��ĕԋp����
    /// </summary>
    /// <returns>KanjiInfos[]</returns>
    public KanjiInfo[] GetKanjiInfo()
    {
        // Resources�t�H���_����KanjiInfos.json���Q��
        string loadJson = Resources.Load<TextAsset>("KanjiInfos").ToString();

        // JSON�f�[�^�ꗗ�̎擾
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        return jsonData.kanjiInfos;
    }
}
