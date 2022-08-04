using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class EnemyGenerator : MonoBehaviour
{
    // 生成する敵オブジェクトのプレハブ
    public GameObject enemyPrefab;

    // スポーンの開始時間
    [SerializeField] float startTime = 1f;

    // スポーンの時間間隔
    [SerializeField] float interval = 6f;

    // スクリプトJsonManagerのコンポーネントを格納する変数
    private JsonManager jsonManager;

    // 漢字配列
    private KanjiInfo[] kanjiInfos;

    // 漢字データ配列から取得する際に用いる配列番号
    private int arrayNumber = 0;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        // スクリプトJsonManagerコンポーネントを取得
        jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();

        // 漢字配列を初期化し、ランダムにソートする
        // TODO: ステージ選択画面から受け取ったEnumの値をもとに取得できるようにする
        // TODO: ひとまず今はFIRSTから受け取れるようにしている
        kanjiInfos = jsonManager.GetKanjiInfoByGradeType(GradeType.FIRST);

        // ランダムソートの実行
        kanjiInfos = kanjiInfos.OrderBy(i => Guid.NewGuid()).ToArray();

        // 繰り返し関数を実行する（spawnを1秒後に6秒刻みで実行）
        InvokeRepeating("Spawn", startTime, interval);

        Debug.Log(enemyPrefab.GetComponent<SpriteRenderer>().bounds.size.x);
    }

    /// <summary>
    /// 敵オブジェクトの生成
    /// </summary>
    private void Spawn()
    {
        // 自機の移動座標最小値をビューポートから取得して、Enemyオブジェクトの大きさ分変更する（最小値は0,0）
        Vector2 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.08f, 0.08f));
        // 自機の移動座標最大値ををビューポートから取得（最大値は1,1）
        Vector2 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.92f, 0.92f));

        // 生成位置（x軸）をランダムに設定
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(minCoord.x, maxCoord.x)// 生成するx軸の範囲。今回のゲーム画面の横幅の座標に対応
            , transform.position.y
            , transform.position.z
        );

        // スクリプトEnemyのkanjiInfoを初期化
        // 注意点：Instantiateを行う前に初期化しないとエラーとなる
        enemyPrefab.GetComponent<Enemy>().SetKanjiText(kanjiInfos[arrayNumber]);

        //enemyをインスタンス化する
        Instantiate(
            enemyPrefab// 生成する敵オブジェクト
            , spawnPosition// 生成する場所
            , transform.rotation// 生成時の向き
        );

        // 漢字をセットする度にarrayNumberをインクリメントし、
        // kanjiInfos配列の要素数よりも上回った時点で再度0で初期化する
        arrayNumber++;
        if (arrayNumber >= kanjiInfos.Length)
        {
            arrayNumber = 0;
        }
    }
}
