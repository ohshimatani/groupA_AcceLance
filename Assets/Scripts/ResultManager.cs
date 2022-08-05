using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    private const string BEST_SCORE_PREFS_KEY = "bestScore";

    private void Start()
    {
        // 今回のスコアと今までの最高スコアを取得する
        int thisScore = GameManager.score;
        int bestScore = PlayerPrefs.GetInt(BEST_SCORE_PREFS_KEY, 0);

        // 今回の到達ランク（惑星）を取得
        Planet planet = GameManager.currentPlanet;

        // スコアに関するText、ランクのImageを反映する
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.SetThisScoreText(thisScore.ToString());
        resultViewController.SetBestScoreText(bestScore.ToString());
        resultViewController.SetViewPropertyByPlanet(planet);

        // 最高スコアの更新された場合、bestScoreを上書きし、「さい高記ろく！」を画面上に表示する
        if (thisScore > bestScore)
        {
            // PlayerPrefsを更新および保存
            PlayerPrefs.SetInt(BEST_SCORE_PREFS_KEY, thisScore);
            PlayerPrefs.Save();

            resultViewController.SetActiveBestScoreNotation(true);
        }
        else
        {
            resultViewController.SetActiveBestScoreNotation(false);
        }

        // アニメーションを行う
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
