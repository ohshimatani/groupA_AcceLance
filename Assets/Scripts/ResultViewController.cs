using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour
{
    // 枠内のImage
    [SerializeField] Image planetImage;

    // 「〇〇 まで とうたつ！」のText
    [SerializeField] Text planetNameText;

    // たおした数
    [SerializeField] Text thisScoreText;

    // 最高スコア
    [SerializeField] Text bestScoreText;

    // 「さい高記ろく！」の表示Text
    [SerializeField] GameObject bestScoreNotation;

    /// <summary>
    /// 今回のスコアをテキストに表示
    /// </summary>
    /// <param name="thisScore"></param>
    public void SetThisScoreText(string thisScore)
    {
        thisScoreText.text = thisScore;
    }

    /// <summary>
    /// 今までの最高スコアをテキストに表示
    /// </summary>
    /// <param name="bestScore"></param>
    public void SetBestScoreText(string bestScore)
    {
        bestScoreText.text = bestScore;
    }

    /// <summary>
    /// 「さい高記ろく！」を表示するか否か
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActiveBestScoreNotation(bool isActive)
    {
        bestScoreNotation.SetActive(isActive);
    }

    /// <summary>
    /// ImageとTextを反映させる
    /// </summary>
    /// <param name="planet"></param>
    public void SetViewPropertyByPlanet(Planet planet)
    {
        // Textに反映
        planetNameText.text = planet.nameJ + " まで とうたつ！";

        // 画像を反映
        planetImage.sprite = planet.sprite;
    }
}
