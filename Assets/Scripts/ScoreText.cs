using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // �t�B�[���h
    private Text scoreText;

    /// <summary>
    /// �X�R�A�̐������O�ŏ�����
    /// </summary>
    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    /// <summary>
    /// Text���Z�b�g����
    /// </summary>
    public void SetText(string score)
    {
        scoreText.text = score;
    }
}
