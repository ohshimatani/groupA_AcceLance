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
    private float playerPosition = -5.4f;

    // アニメーションの時間（秒）
    private float duration = 2f;

    /// <summary>
    /// Playerをランクに応じてアニメーションさせる
    /// </summary>
    public void Animate()
    {
        this.transform.DOMoveX(playerPosition, duration);
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
