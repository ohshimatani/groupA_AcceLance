using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    // �e�f���N���X��臒l�ii�Ԗڂ̗v�f�������Ni�̍ő�l�j
    // TODO:�����͉��u���B���k�̏㌈�肷��
    private int[] planetThresholds = { 3, 5, 10, 12, 15, 20, 30 };

    // �e�f���N���X�̖��O
    private string[] planetNames = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

    // �e�f���N���X�̖��O�i���{�ꖼ�j
    private string[] planetNamesJ = { "����", "����", "�n��", "�ΐ�", "�ؐ�", "�y��", "�V����", "�C����" };


    /// <summary>
    /// ����̃X�R�A����A�����N(0~7)�𔻒f���ԋp����֐�
    /// </summary>
    /// <param name="thisScore">����̃X�R�A</param>
    /// <returns>�����N��\������(0~7)</returns>
    public int judgeRank(int thisScore) {
        for (int i = 0; i < planetThresholds.Length; i++) {
            // �e�f���N���X��臒l�Ƃ̔�r���s��
            if (thisScore <= planetThresholds[i]) {
                return i;
            }
        }
        return planetThresholds.Length;
    }


    /// <summary>
    /// �����N�ɉ������f���̖��O��ԋp����֐��i�p��j
    /// </summary>
    /// <param name="rank">�����N��\������(0~7)</param>
    /// <returns>�f���̖��O�i�p��j</returns>
    public string getRankName(int rank) {
        return planetNames[rank];
    }


    /// <summary>
    /// �����N�ɉ������f���̖��O��ԋp����֐��i���{��j
    /// </summary>
    /// <param name="rank">�����N��\������(0~7)</param>
    /// <returns>�f���̓��{�ꖼ</returns>
    public string getRankNameJ(int rank) {
        return planetNamesJ[rank];
    }


}
