using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetImageController : MonoBehaviour {

    // 枠内のImage
    private Image planetImage;

    // 「〇〇 まで とうたつ！」のText
    private Text planetNameText;

    // ランクを表す数字
    private Planet planet;

    // 今回のスコア
    private int thisScore;

    void Start() {
        // 各種コンポーネントを取得
        planetImage = GetComponent<Image>();
        planetNameText = GameObject.Find("PlanetNameText").GetComponent<Text>();

        // スコアを取得
        // TODO:前画面からスコアを取得する
        PlayerPrefs.SetString("thisScore", "25");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // ランクを判断
        ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        planet = scoreManager.JudgeRank(thisScore);

        // Playerの位置（アニメーションの終点）をResultPlayerControllerに指定
        ResultPlayerController player = GameObject.Find("Player").GetComponent<ResultPlayerController>();
        player.PlayerPosition = planet.PlayerPosition;

        // Textに反映
        planetNameText.text = planet.NameJ + " まで とうたつ！";

        // 画像を反映
        planetImage.sprite = planet.Sprite;

        // Playerのアニメーションを発動
        player.Animate();
    }



}
