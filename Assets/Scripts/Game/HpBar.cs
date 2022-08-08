using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // 最大体力
    private int maxHp;

    // HPバーの描画用スライダー
    private Slider hpBar;

    /// <summary>
    /// HPバー関連の初期設定
    /// </summary>
    public void InitializedHpBar(int hp)
    {
        maxHp = hp;
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;
    }

    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// damagePointの分だけ体力を減らす
    /// </summary>
    /// <param name="damagePoint"></param>
    public void SetHpBarValue(int hp)
    {
        hpBar.value = hp;
    }
}
