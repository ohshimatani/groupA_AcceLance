using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // スクリプトSpaceShipのコンポーネントを格納する変数
    private SpaceShip spaceShip;

    // スクリプトScoreNumberのコンポーネントを格納する変数
    private ScoreNumber scoreNumber;

    public KanjiInfo kanjiInfo;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        scoreNumber = GameObject.Find("ScoreNumber").GetComponent<ScoreNumber>();

        // 画面上から下に移動させる
        spaceShip.Move(transform.up * -1);

        // 弾の発射処理を実行
        StartCoroutine("Shot");
    }

    public void SetKanjiText(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        GameObject canvasObject = gameObject.transform.Find("Canvas").gameObject;
        GameObject textObject = canvasObject.transform.Find("Text").gameObject;
        textObject.GetComponent<Text>().text = kanjiInfo.kanji;
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

                // Scoreの加算処理
                scoreNumber.IncrementScoreNumber();

                // Json情報の上書き
                // TODO: リザルト画面への移行タイミングでまとめて行なっても良い
                JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
                jsonManager.UpdateDefeatCountByKanjiInfo(kanjiInfo);
                jsonManager.WriteJsonData();

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
                // 子要素のオブジェクト名を取得
                string gameObjectName = transform.GetChild(i).gameObject.name;

                // ShotPositionオブジェクトのみ、弾を生成する
                if (gameObjectName.Contains("ShotPosition"))
                {
                    // 子要素を全て取得する
                    // TODO: 複数の弾を発射させるか否かによって処理を変える
                    Transform shotPosition = transform.GetChild(i);

                    // 弾をプレイやーと同じ位置/角度で生成
                    spaceShip.Shot(shotPosition);
                }
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
