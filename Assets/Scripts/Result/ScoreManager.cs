using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    // 各惑星クラスの閾値（i番目の要素がランクiの最大値）
    // TODO:数字は仮置き。相談の上決定する
    private int[] planetThresholds = { 3, 5, 10, 12, 15, 20, 30 };

    // 各惑星クラスの名前
    private string[] planetNames = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

    // 各惑星クラスの名前（日本語名）
    private string[] planetNamesJ = { "水星", "金星", "地球", "火星", "木星", "土星", "天王星", "海王星" };


    /// <summary>
    /// 今回のスコアから、ランク(0~7)を判断し返却する関数
    /// </summary>
    /// <param name="thisScore">今回のスコア</param>
    /// <returns>ランクを表す数字(0~7)</returns>
    public int judgeRank(int thisScore) {
        for (int i = 0; i < planetThresholds.Length; i++) {
            // 各惑星クラスの閾値との比較を行う
            if (thisScore <= planetThresholds[i]) {
                return i;
            }
        }
        return planetThresholds.Length;
    }


    /// <summary>
    /// ランクに応じた惑星の名前を返却する関数（英語）
    /// </summary>
    /// <param name="rank">ランクを表す数字(0~7)</param>
    /// <returns>惑星の名前（英語）</returns>
    public string getRankName(int rank) {
        return planetNames[rank];
    }


    /// <summary>
    /// ランクに応じた惑星の名前を返却する関数（日本語）
    /// </summary>
    /// <param name="rank">ランクを表す数字(0~7)</param>
    /// <returns>惑星の日本語名</returns>
    public string getRankNameJ(int rank) {
        return planetNamesJ[rank];
    }


}
