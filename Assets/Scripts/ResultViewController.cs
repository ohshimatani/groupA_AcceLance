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
