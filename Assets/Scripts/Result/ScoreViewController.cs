using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewController : MonoBehaviour {

    // 今回のスコアのText
    private Text thisScoreText;
    // ベストスコアのText
    private Text bestScoreText;
    // 「さい高記ろく！」の表示Text
    [SerializeField] GameObject bestScoreNotation;
    

    private void Start() {
        // 該当GameObjectをそれぞれGetComponent
        thisScoreText = GameObject.Find("ThisScoreNumber").GetComponent<Text>();
        bestScoreText = GameObject.Find("BestScoreNumber").GetComponent<Text>();

        // それぞれのキーを参照。キー登録がなければデフォルトで"0"を取得
        string thisScore = PlayerPrefs.GetString("thisScore", "0");
        string bestScore = PlayerPrefs.GetString("bestScore", "0");

        // Textに反映
        thisScoreText.text = thisScore;
        bestScoreText.text = bestScore;

        // ベストスコアかどうか判定し、Notationの表示/非表示を選択
        if (isBestScore()) {
            // 今回のスコアがベストスコアなら、PlayerPrefsのbestScoreも更新する
            PlayerPrefs.SetString("bestScore", thisScoreText.text);
            PlayerPrefs.Save();
            bestScoreNotation.SetActive(true);
        } else {
            bestScoreNotation.SetActive(false);
        }

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
