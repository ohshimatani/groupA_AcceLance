using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2DおよびAnimatorコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]

/// <summary>
/// プレイやーと敵オブジェクトの共通要素を記載するクラス
/// </summary>
public class SpaceShip : MonoBehaviour
{
    // オブジェクトの移動スピードを格納する変数
    public float speed;

    // プレイヤー・敵のHP
    [SerializeField] int hp;

    // ダメージポイント
    private const int DAMAGE_POINT = 1;

    // 弾を撃つ間隔を格納する変数
    public float shotDelay;

    // 弾のプレハブを格納する変数
    public GameObject bullet;

    // Rigidbody2Dコンポーネントを格納する変数
    private Rigidbody2D rigidBody;

    // 爆発のPrefab
    public GameObject explosion;

    // アニメーターコンポーネント
    private Animator animator;

    /// <summary>
    /// ゲーム起動時の処理
    /// </summary>
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 爆発の処理
    /// </summary>
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    /// <summary>
    /// ダメージ処理（1ずつダメージを食らう）
    /// </summary>
    public void damage()
    {
        hp -= DAMAGE_POINT;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int getHp()
    {
        return hp;
    }

    /// <summary>
    /// Start関数
    /// </summary>
    /// <param name="origin">オブジェクトの座標</param>
    public void Shot(Transform origin)
    {
        // 弾を引数originと同じ位置/角度で生成
        Instantiate(bullet, origin.position, origin.rotation);
    }

    /// <summary>
    /// オブジェクトの移動処理
    /// </summary>
    /// <param name="direction">オブジェクトの移動方向</param>
    public void Move(Vector2 direction)
    {
        // Rigidbody2Dコンポーネントのvelocityに移動方向と移動速度を掛けた値を渡す
        rigidBody.velocity = direction * speed;
    }
}
