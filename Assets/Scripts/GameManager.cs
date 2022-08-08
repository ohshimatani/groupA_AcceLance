using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 現在のスコア
    public static int score { get; private set; }

    // スコアを表示するテキストとそのコンポーネント
    [SerializeField] GameObject scoreTextObject;
    private ScoreText scoreText;

    // ゲーム画面上の惑星画像を制御するクラス
    private GamePlanetViewController gamePlanetViewController;

    // 惑星の配列
    private Planet[] planets;

    // 現在のランク（惑星）を記録
    public static Planet currentPlanet { get; private set; }

    private void Start()
    {
        // スコアを0で初期化
        score = 0;

        scoreText = scoreTextObject.GetComponent<ScoreText>();

        planets = new Planet[] {
            new Planet("Mercury", "水星", 0, -5.4f)
            , new Planet("Venus", "金星", 4, -4.33f)
            , new Planet("Earth", "地球", 8, -3f)
            , new Planet("Mars", "火星", 11, -1.7f)
            , new Planet("Jupiter", "木星", 16, 0f)
            , new Planet("Saturn", "土星", 21, 2.73f)
            , new Planet("Uranus", "天王星", 31, 4.87f)
            , new Planet("Neptune", "海王星", 51, 6.35f)
        };

        // 現在のランクの初期値は水星とする
        currentPlanet = planets[0];

        // 惑星の画像をセットする
        gamePlanetViewController = GameObject.Find("GamePlanetViewController").GetComponent<GamePlanetViewController>();
        gamePlanetViewController.InitCurrentPlanetImage(currentPlanet);
    }

    /// <summary>
    /// スコアを加算する
    /// </summary>
    public void IncrementScore()
    {
        score++;
        scoreText.SetText(score.ToString());

        // 必要に応じてランクを更新する
        UpdateCurrentPlanet();
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    public void GameOver()
    {
        // JSONへの書き込み処理
        JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
        jsonManager.WriteJsonData();

        // リザルト画面に遷移
        SceneManager.LoadScene("Result");
    }

    /// <summary>
    /// スコアが加算された際に、条件に応じてランクを更新する
    /// </summary>
    private void UpdateCurrentPlanet()
    {
        // 最大スコアよりも上である場合は処理を行わない
        if (score > planets[planets.Length-1].scoreMin)
        {
            return;
        }

        foreach (Planet planet in planets)
        {
            if (score == planet.scoreMin)
            {
                // 惑星の画像を更新
                currentPlanet = planet;
                
                // 惑星の画像をチェンジする
                gamePlanetViewController.ChangeNextPlanet(currentPlanet);

                return;
            }
        }
    }
}
