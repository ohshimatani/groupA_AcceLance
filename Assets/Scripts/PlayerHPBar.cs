using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{

    // フィールド
    private int maxHp = 100;
    private int currentHp;
    public Slider playerHpBar;

    /// <summary>
    /// HPのmaxを設定＆現在のHPを満タンに
    /// </summary>
    void Start()
    {
        playerHpBar = GetComponent<Slider>();
        playerHpBar.maxValue = maxHp;
        currentHp = maxHp;
        playerHpBar.value = currentHp;
    }

    /// <summary>
    /// 一秒毎に10ダメージ受ける処理
    /// （デバッグ用の処理。本番では不要）
    /// </summary>
    private float timeleft;
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;
            ChangePlayerHpBar(10);
        }
    }

    /// <summary>
    /// プレイヤーがダメージを受けた時の処理
    /// damagePointの分だけ体力を減らす
    /// </summary>
    /// <param name="damagePoint"></param>
    public void ChangePlayerHpBar(int damagePoint)
    {
        // 現在のHPをdamagePoint分減らす
        currentHp -= damagePoint;

        // 現在のHPが0を下回っている場合は値を0とする
        if (currentHp <= 0)
        {
            playerHpBar.value = 0;
        }
        else
        {
            playerHpBar.value = currentHp;
        }
    }
}
