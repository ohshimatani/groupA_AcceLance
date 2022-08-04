using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {
    // 惑星の名前（英語）
    private string nameE;

    // 惑星の名前（日本語）
    private string nameJ;

    // スコアのMax値とMin値
    private int scoreMin;

    // プラネットの画像（スプライト）
    private Sprite sprite;

    private float position;

    public Planet(string nameE, string nameJ, int scoreMin, float position)
    {
        this.nameE = nameE;
        this.nameJ = nameJ;
        this.scoreMin = scoreMin;
        this.sprite = Resources.Load<Sprite>("Planets/" + NameE);
        this.position = position;
    }

    /// <summary>
    /// nameJのアクセッサ
    /// </summary>
    public string NameJ {
        get {
            return nameJ;
        }
        set {
            nameJ = value;
        }
    }

    /// <summary>
    /// nameEのアクセッサ
    /// </summary>
    public string NameE {
        get {
            return nameE;
        }
        set {
            nameE = value;
        }
    }

    /// <summary>
    /// scoreMinのアクセッサ
    /// </summary>
    public int ScoreMin {
        get {
            return scoreMin;
        }
        set {
            scoreMin = value;
        }
    }

    /// <summary>
    /// planetSpriteのアクセッサ
    /// </summary>
    public Sprite Sprite {
        get {
            return sprite;
        }
        set {
            sprite = value;
        }
    }


}
