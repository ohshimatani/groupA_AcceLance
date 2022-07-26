using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewController : MonoBehaviour {

    private Text thisScoreText;
    private Text bestScoreText;
    [SerializeField] GameObject bestScoreNotation;
    

    private void Start() {
        // 該当GameObjectをそれぞれGetComponent
        thisScoreText = GameObject.Find("ThisScoreNumber").GetComponent<Text>();
        bestScoreText = GameObject.Find("BestScoreNumber").GetComponent<Text>();

        ReflectThisScore();
        ReflectBestScore();

        // ベストスコアかどうか判定し、
        if (isBestScore()) {
            bestScoreNotation.SetActive(true);
        } else {
            bestScoreNotation.SetActive(false);
        }

    }


    /// <summary>
    /// PlayerPrefsから今回のスコアを参照し、Textに反映
    /// </summary>
    private void ReflectThisScore() {
        // "thisScore"キーを参照。キー登録がなければデフォルトで"0"を取得
        string thisScore = PlayerPrefs.GetString("thisScore", "0");

        // Textに反映
        thisScoreText.text = thisScore;
    }


    /// <summary>
    /// PlayerPrefsからベストスコアを参照し、Textに反映
    /// </summary>
    private void ReflectBestScore() {
        // "bestScore"キーを参照。キー登録がなければデフォルトで"0"を取得
        string bestScore = PlayerPrefs.GetString("bestScore", "0");

        // Textに反映
        bestScoreText.text = bestScore;
    }


    /// <summary>
    /// 今回のスコアがベストスコアかどうかを判定
    /// </summary>
    /// <returns></returns>
    private bool isBestScore() {
        int thisScore = int.Parse(thisScoreText.text);
        int bestScore = int.Parse(bestScoreText.text);

        if (thisScore >= bestScore) {
            return true;
        } else {
            return false;
        }
    }

}
