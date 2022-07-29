using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {
    // 惑星の名前（日本語）
    private string nameJ;

    // 惑星の名前（英語）
    private string nameE;

    // スコアのMax値とMin値
    private int scoreMin;

    public Planet(string nameJ, string nameE, int scoreMin) {
        this.nameJ = nameJ;
        this.nameE = nameE;
        this.scoreMin = scoreMin;
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


}
