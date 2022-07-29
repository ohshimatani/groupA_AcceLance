using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetImageController : MonoBehaviour {

    // Resourcesファイル内のPlanet Image
    private Sprite planetSprite;

    // 枠内のImage
    private Image planetImage;

    // 「〇〇クラス！」のText
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
        PlayerPrefs.SetString("thisScore", "11");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // ランクを判断
        ScoreManager scoreManager = new ScoreManager();
        planet = scoreManager.judgeRank(thisScore);
        Debug.Log(thisScore);
        Debug.Log(planet.NameJ);

        // Resoucesファイルからスコアに応じた画像を取得
        planetSprite = Resources.Load<Sprite>("Planets/" + planet.NameE);

        // Textに反映
        planetNameText.text = planet.NameJ + " まで とうたつ！";

        // 画像を反映
        planetImage.sprite = planetSprite;
    }



}
