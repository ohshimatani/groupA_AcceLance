using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2Dコンポーネントを必須にする
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    // 弾の移動スピード
    public int speed = 10;

    // ゲームオブジェクト生成から削除するまでの時間
    public float lifeTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ローカル座標のY軸方向に移動する
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}
