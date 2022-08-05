using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // フィールド
    private Text scoreText;

    /// <summary>
    /// スコアの数字を０で初期化
    /// </summary>
    void Start() {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    /// <summary>
    /// Textをセットする
    /// </summary>
    public void SetText(string score)
    {
        scoreText.text = score;
    }
}
