using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyBigVer : MonoBehaviour
{
    // スクリプトSpaceShipのコンポーネントを格納する変数
    private SpaceShip spaceShip;

    // スクリプトScoreNumberのコンポーネントを格納する変数
    private ScoreNumber scoreNumber;

    public KanjiInfo kanjiInfo;

    // スクリプトPlayerHpBarのコンポーネントを格納する変数
    PlayerHpBar enemyHpBar;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        scoreNumber = GameObject.Find("ScoreNumber").GetComponent<ScoreNumber>();

        // HPバーの初期設定
        // TODO; えねみーHPBarを後で作る
        GameObject canvasObject = gameObject.transform.Find("Canvas").gameObject;
        enemyHpBar = canvasObject.transform.Find("EnemyHPBar").GetComponent<PlayerHpBar>();
        enemyHpBar.InitializedHpBar(spaceShip.getHp());


        //-----次の移動処理を多様化する

        // <<< Enemy.cs
        //
        // 画面上から下に移動させる
        //spaceShip.Move(transform.up * -1);
        //
        //-----
        // >>> EnemyBigVer.cs
        EnemyDirection enemyDirection = new EnemyDirection();

        // 0～2（方向の種類）の乱数を生成
        System.Random randomGenerator = new System.Random();
        int directionTypeNumber = 2;
        int randomNumber = randomGenerator.Next(0, directionTypeNumber);

        // ランダムに宇宙船の進行方向を決定
        Vector2 direction;
        switch(randomNumber)
        {
            case 0:
                // 真下へ移動
                direction = enemyDirection.StraightDirection();
                break;
            case 1:
                // 左下へ移動
                direction = enemyDirection.LowerLeftDirection();
                break;
            case 2:
                // 右下へ移動
                direction = enemyDirection.LowerRightDirection();
                break;
            default:
                // デフォルトは真下へ移動
                direction = enemyDirection.StraightDirection();
                break;
        }
        spaceShip.Move(direction);



        //-----移動処理の多様化処理、ここまで



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

            // HPバーの変更処理
            enemyHpBar.SetPlayerHpBar(spaceShip.getHp());

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
