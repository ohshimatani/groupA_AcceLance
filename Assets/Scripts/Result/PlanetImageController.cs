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
    private int rank;

    // 今回のスコア
    private int thisScore;


    void Start() {
        // 各種コンポーネントを取得
        planetImage = GetComponent<Image>();
        planetNameText = GameObject.Find("PlanetNameText").GetComponent<Text>();

        // スコアを取得
        PlayerPrefs.SetString("thisScore", "11");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // ランクを判断
        ScoreManager scoreManager = new ScoreManager();
        rank = scoreManager.judgeRank(thisScore);
        Debug.Log(rank);

        // ランクから惑星の名前（英語・日本語）をそれぞれ得る
        string planetName = scoreManager.getRankName(rank);
        string planetNameJ = scoreManager.getRankNameJ(rank);

        // Resoucesファイルからスコアに応じた画像を取得
        planetSprite = Resources.Load<Sprite>("Planets/" + planetName);

        // Textに反映
        planetNameText.text = planetNameJ + " まで とうたつ！";

        // 画像を反映
        planetImage.sprite = planetSprite;
    }



}
