using System.Collections;
using System.Collections.Generic;


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

    // �w�N
    public int gakunen;

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
    public void IncrementDefeatCount()
    {
        defeat_count++;
    }

    /// <summary>
    /// obj�Ǝ������g�������̎���True��Ԃ�
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>bool</returns>
    public override bool Equals(object obj)
    {
        // obj��null�̏ꍇ��false��Ԃ�
        if (obj == null)
        {
            return false;
        }

        // �^���Ⴄ�ꍇ��false��Ԃ�
        if (this.GetType() != obj.GetType())
        {
            return false;
        }

        // KanjiInfo�^�ɃL���X�g
        KanjiInfo kanjiInfo = (KanjiInfo)obj;

        // ����ID�������ł���ꍇ��true��Ԃ�
        if (this.kanji_id == kanjiInfo.kanji_id)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Equals��true��Ԃ��Ƃ��ɓ����l��Ԃ�
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.kanji_id;
    }

    public override string ToString()
    {
        return "Info: " + kanji_id + " " + kanji + " " + defeat_count;
    }
}
