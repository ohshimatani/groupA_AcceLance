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

    // 学年
    public int gakunen;

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
    public void IncrementDefeatCount()
    {
        defeat_count++;
    }

    /// <summary>
    /// objと自分自身が等価の時はTrueを返す
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>bool</returns>
    public override bool Equals(object obj)
    {
        // objがnullの場合はfalseを返す
        if (obj == null)
        {
            return false;
        }

        // 型が違う場合はfalseを返す
        if (this.GetType() != obj.GetType())
        {
            return false;
        }

        // KanjiInfo型にキャスト
        KanjiInfo kanjiInfo = (KanjiInfo)obj;

        // 漢字IDが同じである場合はtrueを返す
        if (this.kanji_id == kanjiInfo.kanji_id)
        {
            return true;
        }

        return false;
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

    /// <summary>
    /// 漢字IDに該当する
    /// </summary>
    /// <param name="kanjiId"></param>
    public void UpdateDefeatCountByKanjiInfo(KanjiInfo kanjiInfo)
    {
        int index = Array.IndexOf(kanjiInfos, kanjiInfo);
        kanjiInfos[index].IncrementDefeatCount();
    }

    /// <summary>
    /// 学年に該当するKanjiInfo配列を取得し、返却する
    /// </summary>
    /// <param name="gakunen"></param>
    /// <returns>KanjiInfo[]</returns>
    private KanjiInfo[] GetKanjiInfoByGakunen(int gakunen)
    {
        List<KanjiInfo> kanjiInfoList = kanjiInfos.ToList();
        return kanjiInfoList.FindAll(x => x.gakunen == gakunen).ToArray();
    }

    /// <summary>
    /// 指定された学年に該当する配列要素のみを抽出する
    /// </summary>
    /// <param name="gakunen">学年</param>
    /// <returns></returns>
    public KanjiInfo[] GetKanjiInfoByStageMode(StageMode stageMode)
    {
        switch (stageMode)
        {
            // 小学1年生&2年生の配列を返却
            case StageMode.ALL:
                return kanjiInfos;
            // 小学1年生の配列を返却
            case StageMode.GAKUNEN_1:
                return GetKanjiInfoByGakunen((int)stageMode);
            // 小学2年生の配列を返却
            case StageMode.GAKUNEN_2:
                return GetKanjiInfoByGakunen((int)stageMode);
            // 例外処理
            default:
                throw new Exception("引数がEnum:StageModeに該当しません");
        }
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
