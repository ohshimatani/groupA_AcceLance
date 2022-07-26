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

/// <summary>
/// StageModeのEnum
/// </summary>
public enum StageMode
{
    ALL,
    GAKUNEN_1 = 1,
    GAKUNEN_2 = 2
}

public class JsonReader : MonoBehaviour
{
    // 読み込むJSONファイルの名前
    private const string JSON_FILE_NAME = "KanjiInfos";

    // 漢字情報の配列
    private KanjiInfo[] kanjiInfos;

    /// <summary>
    /// KanjiInfos.jsonを読み込み、中身の値を返却する
    /// </summary>
    /// <returns>KanjiInfo[]</returns>
    private KanjiInfo[] ReadJsonData()
    {
        // ResourcesフォルダからKanjiInfos.jsonを参照
        string loadJson = Resources.Load<TextAsset>(JSON_FILE_NAME).ToString();

        // JSONデータ一覧の取得
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        return jsonData.kanjiInfos;
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
