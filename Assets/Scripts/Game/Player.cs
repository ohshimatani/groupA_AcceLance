using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // スクリプトSpaceShipのコンポーネントを格納する変数
    SpaceShip spaceShip;

    // スクリプトGameManagerのコンポーネントを格納する変数
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

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
        RestrictPlayerMovement();
    }

    /// <summary>
    /// 自機の移動制限処理
    /// </summary>
    void RestrictPlayerMovement()
    {
        // 自機の移動座標最小値をビューポートから取得（最小値は0,0）
        Vector2 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.1f));
        // 自機の移動座標最大値ををビューポートから取得（最大値は1,1）
        Vector2 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.85f));

        // 自機の座標を取得してベクトル position に格納
        Vector2 position = transform.position;
        // position.x の値を最小値 min 最大値 max の範囲に制限する
        position.x = Mathf.Clamp(position.x, minCoord.x, maxCoord.x);
        // position.y の値を最小値 min 最大値 max の範囲に制限する
        position.y = Mathf.Clamp(position.y, minCoord.y, maxCoord.y);

        // 自機の移動範囲を pos の最小値と最大値の範囲に制限する
        transform.position = position;
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
            // 効果音の再生
            PlayDamageSoundEffect();

            // 弾の削除
            Destroy(collider.gameObject);
        }

        // レイヤー名がEnemyBulletまたはEnemyの場合
        if (layerName == "EnemyBullet" || layerName == "Enemy")
        {
            // ダメージ処理
            spaceShip.Damage();

            // HPバーの変更処理
            spaceShip.hpBar.SetHpBarValue(spaceShip.hp);

            // HPが0になった時の処理
            if (spaceShip.hp <= 0)
            {
                // 爆発処理
                spaceShip.Explosion();
                
                // プレイヤーを削除
                Destroy(gameObject);

                // ゲームオーバー処理を実行
                gameManager.GameOver();
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

    /// <summary>
    /// ダメージを受けた際の効果音
    /// </summary>
    public void PlayDamageSoundEffect()
    {
        AudioClip audioClip = gameObject.GetComponent<AudioSource>().clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
