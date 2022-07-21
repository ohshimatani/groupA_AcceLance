using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        Text scoreNumber = GetComponent<Text>();
        scoreNumber.text = "0";
    }

    private float timeleft;
    // �f�o�b�O�p�̏���
    // �{�Ԃł͕s�v
    void Update() {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 1.0f;
            IncrementScoreNumber();
        }
    }

    /*
     * �X�R�A�i�|�������j���C���N�������g
     * �G���|���ꂽ�Ƃ��ɌĂ΂��z��
    */
    public void IncrementScoreNumber() {
        Text scoreNumber = GetComponent<Text>();
        int score = 0;
        /*scoreNubmer��int�փL���X�g�B
        ��������΃C���N�������g���AString�֍ēx�L���X�g*/
        try {
            score = Int32.Parse(scoreNumber.text);
            score++;
            scoreNumber.text = score.ToString();
        } catch(FormatException) {
            Debug.Log("error: from string to int at ScoreText.cs/IncrementScoreNumber");
        }
    }

    
}
