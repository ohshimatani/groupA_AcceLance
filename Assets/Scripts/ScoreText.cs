using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    /// <summary>
    /// スコアの数字を０で初期化
    /// </summary>
    void Start() {
        Text scoreNumber = GetComponent<Text>();
        scoreNumber.text = "0";
    }

    /// <summary>
    /// 一秒毎にスコアの数がインクリメントされるように
    /// （デバッグ用の処理。本番では不要）
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
    /// スコア（倒した数）をインクリメントするメソッド。
    /// 敵が倒されたときに呼ばれる想定
    /// </summary>
    public void IncrementScore() {
        Text scoreNumber = GetComponent<Text>();
        int score = 0;

        /// <summary>
        /// scoreNubmerをintへキャスト。
        /// 成功すればインクリメントし、Stringへ再度キャスト
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
