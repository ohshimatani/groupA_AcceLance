using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    // フィールド
    private Text scoreNumber;

    /// <summary>
    /// スコアの数字を０で初期化
    /// </summary>
    void Start() {
        scoreNumber = GetComponent<Text>();
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
            IncrementScoreNumber();
        }
    }

    /// <summary>
    /// スコア（倒した数）をインクリメントするメソッド。
    /// 敵が倒されたときに呼ばれる想定
    /// </summary>
    public void IncrementScoreNumber() {
        int currentScore = int.Parse(scoreNumber.text);
        scoreNumber.text = (currentScore + 1).ToString();
    }
}
