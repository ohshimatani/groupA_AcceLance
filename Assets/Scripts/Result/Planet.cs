using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    // 惑星の名前（日本語）
    private string nameJ;

    // 惑星の名前（英語）
    private string nameE;

    // スコアのMax値とMin値
    private int scoreMax;
    private int scoreMin;

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
    /// scoreMaxのアクセッサ
    /// </summary>
    public int ScoreMax {
        get {
            return scoreMax;
        }
        set {
            scoreMax = value;
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
