using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // スクリプトSpaceShipのコンポーネントを格納する変数
    SpaceShip spaceShip;

    // スクリプトPlayerHpBarのコンポーネントを格納する変数
    PlayerHpBar playerHpBar;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();

        // HPバーの初期設定
        playerHpBar = GameObject.Find("PlayerHPBar").GetComponent<PlayerHpBar>();
        playerHpBar.InitializedHpBar(spaceShip.getHp());

        // 弾の発射処理の開始
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        // 右・左の入力値
        float x = Input.GetAxisRaw("Horizontal");
        // 上・下の入力値
        float y = Input.GetAxisRaw("Vertical");

        // 移動する方向を求める
        // xとyの入力値を正規化し、directionに渡す
        Vector2 direction = new Vector2(x, y).normalized;
        spaceShip.Move(direction);
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    /// <param name="collision">衝突対象のCollider2Dコンポーネント</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 衝突オブジェクトのレイヤー名の取得
        string layerName = LayerMask.LayerToName(collider.gameObject.layer);

        // レイヤー名がEnemyBulletの場合
        if (layerName == "EnemyBullet")
        {
            // 弾の削除
            Destroy(collider.gameObject);
        }

        // レイヤー名がEnemyBulletまたはEnemyの場合
        if (layerName == "EnemyBullet" || layerName == "Enemy")
        {
            // ダメージ処理
            spaceShip.damage();

            // HPバーの変更処理
            playerHpBar.SetPlayerHpBar(spaceShip.getHp());

            // HPが0になった時の処理
            if (spaceShip.getHp() <= 0)
            {
                // 爆発処理
                spaceShip.Explosion();

                // プレイヤーを削除
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 弾の発射処理（コルーチン）
    /// </summary>
    /// <returns></returns>
    IEnumerator Shot()
    {
        while (true)
        {
            // 自分の座標情報をShotメソッドの引数に渡す
            spaceShip.Shot(transform);
            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
