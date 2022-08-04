using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 現在のスコア
    public int score { get; private set; } = 0;

    // スコアを表示するテキストとそのコンポーネント
    [SerializeField] GameObject scoreTextObject;
    private ScoreText scoreText;

    private void Start()
    {
        scoreText = scoreTextObject.GetComponent<ScoreText>();
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    public void IncrementScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    public void GameOver()
    {
        // PlayerPrefsに現在のスコアを追加
        PlayerPrefs.SetString("thisScore", score.ToString());

        // リザルト画面に遷移
        SceneManager.LoadScene("Result");
    }
}
