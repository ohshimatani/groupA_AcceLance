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
        string thisScore = PlayerPrefs.GetString("thisScore", "22");

        // Textに反映
        thisScoreText.text = thisScore;
    }

    /// <summary>
    /// PlayerPrefsからベストスコアを参照し、Textに反映
    /// </summary>
    private void ReflectBestScore() {
        // "bestScore"キーを参照。キー登録がなければデフォルトで"0"を取得
        string bestScore = PlayerPrefs.GetString("bestScore", "111");

        // Textに反映
        bestScoreText.text = bestScore;
    }
}
