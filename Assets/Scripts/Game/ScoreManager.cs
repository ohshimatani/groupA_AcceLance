using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager
{

    private Planet[] planets;

    /// <summary>
    /// コンストラクタ：
    /// 太陽系の順番で惑星の要素を持つ配列を作成
    /// </summary>
    /// <returns>太陽系の順番で惑星の要素を持つ配列</returns>
    public ScoreManager()
    {
        planets = new Planet[] {
            new Planet("Mercury", "水星", 0, -5.4f)
            , new Planet("Venus", "金星", 4, -4.33f)
            , new Planet("Earth", "地球", 8, -3f)
            , new Planet("Mars", "火星", 11, -1.7f)
            , new Planet("Jupiter", "木星", 16, 0f)
            , new Planet("Saturn", "土星", 21, 2.73f)
            , new Planet("Uranus", "天王星", 31, 4.87f)
            , new Planet("Neptune", "海王星", 51, 6.35f)
        };

    }

    /// <summary>
    /// スコアに応じた惑星クラスを返す関数
    /// TODO:Gameシーンからランクを受け取る実装に変更する可能性あり
    /// </summary>
    /// <param name="thisScore">今回のスコア</param>
    /// <returns>スコアに応じた惑星クラス</returns>
    public Planet JudgeRank(int thisScore)
    {
        Planet planet = planets.First();

        for (int i = planets.Length - 1; i >= 0; i--)
        {
            planet = planets[i];
            if (thisScore >= planet.scoreMin)
            {
                break;
            }
        }

        return planet;
    }


}
