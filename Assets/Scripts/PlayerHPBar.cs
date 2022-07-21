using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{

    // 最大体力
    private int maxHp;

    // HPバーの描画用スライダー
    private Slider playerHpBar;

    /// <summary>
    /// HPバー関連の初期設定
    /// </summary>
    public void InitializedHpBar(int hp)
    {
        maxHp = hp;
        playerHpBar = GetComponent<Slider>();
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = maxHp;
    }

    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// damagePointの分だけ体力を減らす
    /// </summary>
    /// <param name="damagePoint"></param>
    public void SetPlayerHpBar(int hp)
    {
        playerHpBar.value = hp;
    }
}
