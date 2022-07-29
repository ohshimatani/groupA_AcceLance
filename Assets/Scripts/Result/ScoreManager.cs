using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    /// <summary>
    /// 太陽系の順番で惑星の要素を持つ配列を作成
    /// </summary>
    /// <returns>太陽系の順番で惑星の要素を持つ配列</returns>
    private Planet[] createPlanetArray() {
        // 各惑星クラスの名前
        string[] planetNamesE = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

        // 各惑星クラスの名前（日本語名）
        string[] planetNamesJ = { "水星", "金星", "地球", "火星", "木星", "土星", "天王星", "海王星" };

        // 各惑星クラスの閾値（i番目の要素がランクiの最大値）
        // TODO:数字は仮置き。相談の上決定する
        // 海王星（最高ランク）のScoreMaxは便宜上9999としたが、これでいいのか...?
        int[] planetThresholds = { -1, 3, 7, 10, 15, 20, 30, 50, 9999 };

        // 順番にPlanetの要素を配列に格納
        Planet[] planetArray = new Planet[planetNamesE.Length];
        for (int i = 0; i < planetNamesE.Length; i++) {
            Planet planet = new Planet();
            planet.NameE = planetNamesE[i];
            planet.NameJ = planetNamesJ[i];
            planet.ScoreMin = planetThresholds[i] + 1;
            planet.ScoreMax = planetThresholds[i + 1];
            planetArray[i] = planet;
        }

        return planetArray;
    }

    public Planet judgeRank(int thisScore) {
        
        // 惑星の配列
        Planet[] planetArray = createPlanetArray();
        // 最高ランク（海王星）
        Planet neptune = planetArray.Last();

        for (int i = 0; i < planetArray.Length; i++) {
            Planet planet = planetArray[i];
            // 今回のスコアがどの惑星に該当するかを順番に確かめる
            if (planet.ScoreMin <= thisScore && thisScore <= planet.ScoreMax) {
                return planet;
            }
        }

        return neptune;
    }

    


}
