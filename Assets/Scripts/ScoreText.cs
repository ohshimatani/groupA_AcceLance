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
    // デバッグ用の処理
    // 本番では不要
    void Update() {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 1.0f;
            IncrementScoreNumber();
        }
    }

    /*
     * スコア（倒した数）をインクリメント
     * 敵が倒されたときに呼ばれる想定
    */
    public void IncrementScoreNumber() {
        Text scoreNumber = GetComponent<Text>();
        int score = 0;
        /*scoreNubmerをintへキャスト。
        成功すればインクリメントし、Stringへ再度キャスト*/
        try {
            score = Int32.Parse(scoreNumber.text);
            score++;
            scoreNumber.text = score.ToString();
        } catch(FormatException) {
            Debug.Log("error: from string to int at ScoreText.cs/IncrementScoreNumber");
        }
    }

    
}
