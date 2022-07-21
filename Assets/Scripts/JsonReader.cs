using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonData
{
    public KanjiInfo[] kanjiInfos;
}

[System.Serializable]
public class KanjiInfo
{
    // 漢字
    public string kanji;

    // 音読みのリスト
    public string[] onyomi;

    // 訓読みのリスト
    public string[] kunyomi;

    // 漢字の画数
    public int kakusu;
}

public class JsonReader : MonoBehaviour
{
    /// <summary>
    /// KanjiInfos.jsonを読み込み、KanjiInfoクラス配列として返却する
    /// </summary>
    /// <returns>KanjiInfos[]</returns>
    public KanjiInfo[] GetKanjiInfo()
    {
        // ResourcesフォルダからKanjiInfos.jsonを参照
        string loadJson = Resources.Load<TextAsset>("KanjiInfos").ToString();

        // JSONデータ一覧の取得
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        return jsonData.kanjiInfos;
    }
}
