using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    // 惑星の名前（英語）
    public string nameE { get; set; }

    // 惑星の名前（日本語）
    public string nameJ { get; set; }

    // スコアのMin値
    public int scoreMin { get; set; }

    // プラネットの画像（スプライト）
    public Sprite sprite { get; set; }

    // プレイヤーの位置のX座標(horizontal)
    public float positionX { get; set; }

    public Planet(string nameE, string nameJ, int scoreMin, float positionX)
    {
        this.nameE = nameE;
        this.nameJ = nameJ;
        this.scoreMin = scoreMin;
        this.sprite = Resources.Load<Sprite>("Planets/" + nameE);
        this.positionX = positionX;
    }

}
