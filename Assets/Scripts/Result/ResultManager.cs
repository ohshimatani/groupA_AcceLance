using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    // ランクに該当する惑星
    private Planet planet;

    // 今回のスコア
    private int thisScore;

    /// <summary>
    /// Image, Textへのランクの反映と
    /// アニメーションの実行を行う
    /// </summary>
    private void Start()
    {
        // スコアを取得
        // TODO:前画面からスコアを取得する
        PlayerPrefs.SetString("thisScore", "33");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // ランクを判断
        // TODO: ランクの初期化もGame画面からしたい
        ScoreManager scoreManager = new ScoreManager();
        planet = scoreManager.JudgeRank(thisScore);

        // ImageとTextを反映する
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.ReflectView(planet);

        // アニメーションを行う
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
