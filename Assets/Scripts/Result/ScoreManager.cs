using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private Planet[] planets;

    /// <summary>
    /// 太陽系の順番で惑星の要素を持つ配列を作成
    /// </summary>
    /// <returns>太陽系の順番で惑星の要素を持つ配列</returns>
    private void Start() {
        planets = new Planet[] {
            new Planet("Mercury", "水星", 0)
            , new Planet("Venus", "金星", 4)
            , new Planet("Earth", "地球", 8)
            , new Planet("Mars", "火星", 11)
            , new Planet("Jupiter", "木星", 16)
            , new Planet("Saturn", "土星", 21)
            , new Planet("Uranus", "天王星", 31)
            , new Planet("Neptune", "海王星", 51)
        };

    }

    /// <summary>
    /// スコアに応じた惑星クラスを返す関数
    /// TODO:Gameシーンからランクを受け取る実装に変更する可能性あり
    /// </summary>
    /// <param name="thisScore">今回のスコア</param>
    /// <returns>スコアに応じた惑星クラス</returns>
    public Planet JudgeRank(int thisScore) {
        
        Planet planet = planets.First();

        for (int i = planets.Length - 1; i >= 0; i--) {
            planet = planets[i];
            if (thisScore >= planet.ScoreMin) {
                break;
            }
        }

        return planet;
    }

    


}
