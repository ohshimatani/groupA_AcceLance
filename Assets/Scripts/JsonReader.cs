using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData
{
    public KanjiInfo[] kanjiInfos;
}

/// <summary>
/// �ǂݍ���JSON�̃L�[�ꗗ
/// ���ӓ_�FJSON�t�@�C���̃L�[���ƕϐ����͑�����K�v������
/// </summary>
[System.Serializable]
public class KanjiInfo
{
    // ������ID
    public int kanji_id;

    // ����
    public string kanji;

    // ���ǂ݂̃��X�g
    public string[] onyomi;

    // �P�ǂ݂̃��X�g
    public string[] kunyomi;

    // �����̉搔
    public int kakusu;

    // �|�����G�̐�
    public int defeat_count;

    /// <summary>
    /// �|�����G�̐������Z����
    /// </summary>
    public void AddDefeatCount()
    {
        defeat_count++;
    }

    public override string ToString()
    {
        return "Info: " + kanji_id + " " + kanji + " " + defeat_count;
    }
}

public class JsonReader : MonoBehaviour
{
    // �������̔z��
    private KanjiInfo[] kanjiInfos { get; set; }

    /// <summary>
    /// KanjiInfos.json��ǂݍ��݁AkanjiInfos�z�������������
    /// </summary>
    /// <returns>KanjiInfos[]</returns>
    private void InitKanjiInfo()
    {
        // Resources�t�H���_����KanjiInfos.json���Q��
        string loadJson = Resources.Load<TextAsset>("KanjiInfos").ToString();

        // JSON�f�[�^�ꗗ�̎擾
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        return jsonData.kanjiInfos;
    }
}
