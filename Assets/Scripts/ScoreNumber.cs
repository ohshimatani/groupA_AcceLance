using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNumber : MonoBehaviour {

    // �t�B�[���h
    private Text scoreNumber;

    /// <summary>
    /// �X�R�A�̐������O�ŏ�����
    /// </summary>
    void Start() {
        scoreNumber = GetComponent<Text>();
        scoreNumber.text = "0";
    }

    /// <summary>
    /// �X�R�A�i�|�������j���C���N�������g���郁�\�b�h�B
    /// �G���|���ꂽ�Ƃ��ɌĂ΂��z��
    /// </summary>
    public void IncrementScoreNumber() {
        int currentScore = int.Parse(scoreNumber.text);
        scoreNumber.text = (currentScore + 1).ToString();
    }
}
