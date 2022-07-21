using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    /// <summary>
    /// �X�R�A�̐������O�ŏ�����
    /// </summary>
    void Start() {
        Text scoreNumber = GetComponent<Text>();
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
            IncrementScore();
        }
    }

    /// <summary>
    /// �X�R�A�i�|�������j���C���N�������g���郁�\�b�h�B
    /// �G���|���ꂽ�Ƃ��ɌĂ΂��z��
    /// </summary>
    public void IncrementScore() {
        Text scoreNumber = GetComponent<Text>();
        int score = 0;

        /// <summary>
        /// scoreNubmer��int�փL���X�g�B
        /// ��������΃C���N�������g���AString�֍ēx�L���X�g
        /// </summary>
        try {
            score = Int32.Parse(scoreNumber.text);
            score++;
            scoreNumber.text = score.ToString();
        } catch(FormatException) {
            Debug.Log("error: from string to int at ScoreText.cs/IncrementScoreNumber");
        }
    }

    
}
