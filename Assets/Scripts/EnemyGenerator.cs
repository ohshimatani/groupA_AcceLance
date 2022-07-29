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
        // 繰り返し関数を実行する（spawnを1秒後に6秒刻みで実行）
        InvokeRepeating("Spawn", startTime, interval);

        // スクリプトJsonManagerコンポーネントを取得
        jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();

        // 漢字配列を初期化し、ランダムにソートする
        // TODO: ステージ選択画面から受け取ったEnumの値をもとに取得できるようにする
        // TODO: ひとまず今はGAKUNEN_1から受け取れるようにしている
        kanjiInfos = jsonManager.GetKanjiInfoByStageMode(StageMode.GAKUNEN_1);
        kanjiInfos = kanjiInfos.OrderBy(i => Guid.NewGuid()).ToArray();
    }

    /// <summary>
    /// 敵オブジェクトの生成
    /// </summary>
    private void Spawn()
    {
        // 生成位置（x軸）をランダムに設定
        Vector3 spawnPosition = new Vector3(
            UnityEngine.Random.Range(-9.0f, 9.0f)// 生成するx軸の範囲。今回のゲーム画面の横幅の座標に対応
            , transform.position.y
            , transform.position.z
        );

        //enemyをインスタンス化する
        Instantiate(
            enemyPrefab// 生成する敵オブジェクト
            , spawnPosition// 生成する場所
            , transform.rotation// 生成時の向き
        );

        // スクリプトEnemyのkanjiInfoを初期化
        enemyPrefab.GetComponent<Enemy>().SetKanjiText(kanjiInfos[arrayNumber]);

        // 漢字をセットする度にarrayNumberをインクリメントし、
        // kanjiInfos配列の要素数よりも上回った時点で再度0で初期化する
        arrayNumber++;
        if (arrayNumber >= kanjiInfos.Length)
        {
            arrayNumber = 0;
        }
    }
}
