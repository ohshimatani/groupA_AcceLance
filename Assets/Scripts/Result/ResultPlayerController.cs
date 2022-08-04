using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/// <summary>
/// リザルト画面に置けるプレイヤー（ロケット）のアニメーションを制御するためのクラス
/// </summary>
public class ResultPlayerController : MonoBehaviour
{
    private void Start()
    {
        this.transform.DOMoveX(-1.7f, 2f);
    }
}
