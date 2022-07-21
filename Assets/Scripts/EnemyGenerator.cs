using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    // 生成する敵オブジェクトのプレハブ
    public GameObject enemyPrefab;

    // スポーンの開始時間
    [SerializeField] float startTime = 1f;

    // スポーンの時間間隔
    [SerializeField] float interval = 6f;

    // 漢字データの配列
    private KanjiInfo[] kanjiInfos;

    // 漢字データ配列から取得する際に用いる配列番号
    // TODO: ひとまずデモ用に作ったが後々修正したい
    private int arrayNumber;

    /// <summary>
    /// ゲームスタート時の処理
    /// </summary>
    void Start()
    {
        // 繰り返し関数を実行する（spawnを1秒後に6秒刻みで実行）
        InvokeRepeating("Spawn", startTime, interval);

        // 漢字データの配列を初期化
        kanjiInfos = GameObject.Find("JsonReader").GetComponent<JsonReader>().GetKanjiInfo();

        // ひとまず0で初期化
        arrayNumber = 0;
    }

    /// <summary>
    /// 敵オブジェクトの生成
    /// </summary>
    private void Spawn()
    {
        // 生成位置（x軸）をランダムに設定
        Vector3 spawnPosition = new Vector3(
            Random.Range(-9.0f, 9.0f)// 生成するx軸の範囲。今回のゲーム画面の横幅の座標に対応
            , transform.position.y
            , transform.position.z
        );

        // Enemyプレハブの子オブジェクト"Canvas"を取得
        GameObject canvasObject = enemyPrefab.transform.Find("Canvas").gameObject;

        // Canvasオブジェクトの子オブジェクト"Text"を取得する
        GameObject textObject = canvasObject.transform.Find("Text").gameObject;

        // Text内容に漢字をセット
        textObject.GetComponent<Text>().text = kanjiInfos[arrayNumber].kanji;

        // 漢字をセットする度にarrayNumberをインクリメントし、
        // kanjiInfos配列の要素数よりも上回った時点で再度0で初期化する
        arrayNumber++;
        if (arrayNumber >= kanjiInfos.Length)
        {
            arrayNumber = 0;
        }

        //enemyをインスタンス化する
        Instantiate(
            enemyPrefab// 生成する敵オブジェクト
            , spawnPosition// 生成する場所
            , transform.rotation// 生成時の向き
        );
    }
}
