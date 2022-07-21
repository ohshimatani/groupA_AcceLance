using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // スクリプトSpaceShipのコンポーネントを格納する変数
    SpaceShip spaceShip;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        // 画面上から下に移動させる
        spaceShip.Move(transform.up * -1);
        // 弾の発射処理を実行
        StartCoroutine("Shot");
    }

    /// <summary>
    /// 当たり判定処理
    /// </summary>
    /// <param name="collider">衝突対象のCollider2Dコンポーネント</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // 衝突オブジェクトのレイヤー名の取得
        string layerName = LayerMask.LayerToName(collider.gameObject.layer);

        // レイヤー名がPlayerBulletの場合
        if (layerName == "PlayerBullet")
        {
            // ダメージ処理
            spaceShip.damage();

            // 弾の削除
            Destroy(collider.gameObject);

            // HPが0になった時の処理
            if (spaceShip.getHp() <= 0)
            {
                // 爆発処理
                spaceShip.Explosion();

                // 自身（エネミー）を削除
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
            // 子要素を全て習得する
            for (int i = 0; i < transform.childCount; i++)
            {
                // 子要素を全て取得する
                // TODO: 複数の弾を発射させるか否かによって処理を変える
                Transform shotPosition = transform.GetChild(i);

                // 弾をプレイやーと同じ位置/角度で生成
                spaceShip.Shot(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
