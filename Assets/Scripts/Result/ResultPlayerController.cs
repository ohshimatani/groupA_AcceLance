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
    private float playerPositionX;

    // アニメーションの時間（秒）
    private const float DURATION = 2f;

    private void Start()
    {
        Transform transForm = GameObject.Find("Player").transform;
        playerPositionX = transForm.position.x;
    }

    /// <summary>
    /// Playerをランクに応じてアニメーションさせる
    /// </summary>
    public void Animate()
    {
        this.transform.DOMoveX(playerPositionX, DURATION);
    }

    /// <summary>
    /// playerPositionのアクセッサ
    /// </summary>
    public float PlayerPositionX
    {
        get
        {
            return playerPositionX;
        }
        set
        {
            playerPositionX = value;
        }
    }
}
