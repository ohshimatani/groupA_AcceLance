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
        // 今回のスコア・ランク（到達惑星）をGameManagerから取得
        thisScore = GameManager.score;
        planet = GameManager.currentPlanet;

        // ImageとTextを反映する
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.SetViewPropertyByPlanet(planet);

        // アニメーションを行う
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
