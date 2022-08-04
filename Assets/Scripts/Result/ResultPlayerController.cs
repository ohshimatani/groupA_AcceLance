using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/// <summary>
/// リザルト画面に置けるプレイヤー（ロケット）のアニメーションを制御するためのクラス
/// </summary>
public class ResultPlayerController : MonoBehaviour
{
    // プレイヤーのポジション（PlanetImageControllerからsetされる）
    private float playerPosition;

    private void Start()
    {
        ScoreManager scoreManager = new ScoreManager();
        ScoreManager
        this.transform.DOMoveX(-1.7f, 2f);
    }

    /// <summary>
    /// playerPositionのアクセッサ
    /// </summary>
    public float PlayerPosition
    {
        get
        {
            return playerPosition;
        }
        set
        {
            playerPosition = value;
        }
    }
}
