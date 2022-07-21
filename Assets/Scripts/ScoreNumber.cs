using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

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
    /// ��b���ɃX�R�A�̐����C���N�������g�����悤��
    /// �i�f�o�b�O�p�̏����B�{�Ԃł͕s�v�j
    /// </summary>
    private float timeleft;
    void Update() {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 1.0f;
            IncrementScoreNumber();
        }
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
