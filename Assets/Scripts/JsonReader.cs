using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData
{
    public KanjiInfo[] kanjiInfos;
}

/// <summary>
/// 読み込みJSONのキー一覧
/// 注意点：JSONファイルのキー名と変数名は揃える必要がある
/// </summary>
[System.Serializable]
public class KanjiInfo
{
    // 漢字のID
    public int kanji_id;

    // 漢字
    public string kanji;

    // 音読みのリスト
    public string[] onyomi;

    // 訓読みのリスト
    public string[] kunyomi;

    // 漢字の画数
    public int kakusu;

    // 倒した敵の数
    public int defeat_count;

    /// <summary>
    /// 倒した敵の数を加算する
    /// </summary>
    public void AddDefeatCount()
    {
        defeat_count++;
    }

    public override string ToString()
    {
        return "Info: " + kanji_id + " " + kanji + " " + defeat_count;
    }
}

public class JsonReader : MonoBehaviour
{
    // 漢字情報の配列
    private KanjiInfo[] kanjiInfos { get; set; }

    /// <summary>
    /// KanjiInfos.jsonを読み込み、kanjiInfos配列を初期化する
    /// </summary>
    /// <returns>KanjiInfos[]</returns>
    private void InitKanjiInfo()
    {
        // ResourcesフォルダからKanjiInfos.jsonを参照
        string loadJson = Resources.Load<TextAsset>("KanjiInfos").ToString();

        // JSONデータ一覧の取得
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        kanjiInfos = jsonData.kanjiInfos;
    }

    public void Start()
    {
        InitKanjiInfo();
        foreach (KanjiInfo ki in kanjiInfos)
        {
            Debug.Log(ki.ToString());
        }
    }
}
