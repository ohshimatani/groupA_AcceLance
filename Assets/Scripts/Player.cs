using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        // 自機の移動制限処理を実行
        Clamp();
    }

    /// <summary>
    /// 自機の移動制限処理
    /// </summary>
    void Clamp()
    {
        //自機の移動最小座標（ベクトル）を定義（取りうる最小の値は0,0）
        Vector2 MINVECTOR = new Vector2(0.05f, 0.1f);
        //自機の移動最大座標（ベクトル）を定義（取りうる最大の値は1,1）
        Vector2 MAXVECTOR = new Vector2(0.95f, 0.85f);
        
        // 自機の移動座標最小値をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(MINVECTOR);
        // 自機の移動座標最大値ををビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(MAXVECTOR);

        // 自機の座標を取得してベクトル pos に格納
        Vector2 pos = transform.position;
        // pos.x の値を最小値 min 最大値 max の範囲に制限する
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        // pos.y の値を最小値 min 最大値 max の範囲に制限する
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 自機の移動範囲を pos の最小値と最大値の範囲に制限する
        transform.position = pos;
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

                // PlayerPrefsに最終スコアを格納
                GameObject canvasObject = GameObject.Find("Canvas").gameObject;
                GameObject textObject = canvasObject.transform.Find("ScoreNumber").gameObject;
                string thisScore = textObject.GetComponent<ScoreNumber>().GetScoreNumber();

                PlayerPrefs.SetString("thisScore", thisScore);

                // プレイヤーを削除
                Destroy(gameObject);

                // リザルト画面に遷移
                SceneManager.LoadScene("Result");
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
