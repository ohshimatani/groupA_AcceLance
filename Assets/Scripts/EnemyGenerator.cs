using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    //スポーンの開始時間
    [SerializeField] float startTime = 1f;
    //スポーンの時間間隔
    [SerializeField] float interval = 6f;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        // 繰り返し関数を実行する（spawnを1秒後に6秒刻みで実行）
        InvokeRepeating("Spawn", startTime, interval);
    }

    /// <summary>
    /// 敵オブジェクトの生成
    /// </summary>
    void Spawn()
    {
        // 生成位置（x軸）をランダムに設定
        Vector3 spawnPosition = new Vector3(
            Random.Range(-9.0f, 9.0f)// 生成するx軸の範囲。今回のゲーム画面の横幅の座標に対応
            , transform.position.y
            , transform.position.z
        );

        //enemyをインスタンス化する
        Instantiate(enemyPrefab// 生成するもの
            , spawnPosition// 生成する場所
            , transform.rotation// 生成時の向き
        );
    }
}
