using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/// <summary>
/// リザルト画面に置けるプレイヤー（ロケット）のアニメーションを制御するためのクラス
/// </summary>
public class ResultPlayerAnimator : MonoBehaviour
{
    // アニメーションの時間（秒）
    private const float DURATION = 2f;

    /// <summary>
    /// 引数で指定された場所までアニメーションをさせる
    /// </summary>
    /// <param name="positionX"></param>
    public void Animate(float positionX)
    {
        transform.DOMoveX(positionX, DURATION);
    }

}
