using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


/// <summary>
/// 読み込んだJSON情報を格納するクラス
/// </summary>
public class JsonData
{
    public KanjiInfo[] kanjiInfos;
}

public class JsonManager : MonoBehaviour
{
    // 読み込むJSONファイルの名前
    private const string JSON_FILE = "KanjiInfos.json";

    // 漢字情報の配列
    private static KanjiInfo[] kanjiInfos;

    /// <summary>
    /// KanjiInfos.jsonを読み込み、kanjiInfosを初期化する
    /// </summary>
    private KanjiInfo[] ReadJsonData()
    {
        string loadJson = null;

        // 書き込みが既に完了している場合は、Resourcesとは別の個所から読み込みを行う
        if (File.Exists(Application.persistentDataPath + JSON_FILE))
        {
            StreamReader streamReader = new StreamReader(Application.persistentDataPath + JSON_FILE);
            loadJson = streamReader.ReadToEnd();
        }
        else
        {
            // 最初だけResourcesフォルダからの読み込みを行う（ビルド時にエラーが出たのでひとまず応急処置）
            loadJson = Resources.Load<TextAsset>("Assets/Resources/" + JSON_FILE).ToString();
        }

        // JSONデータ一覧の取得
        JsonData jsonData = new JsonData();
        JsonUtility.FromJsonOverwrite(loadJson, jsonData);

        return jsonData.kanjiInfos;
    }

    /// <summary>
    /// JSONファイルの書き出し
    /// </summary>
    public void WriteJsonData()
    {
        // 書き込むKanjiInfo配列を初期化する
        JsonData jsonData = new JsonData();
        jsonData.kanjiInfos = (KanjiInfo[])kanjiInfos.Clone();

        // 書き込み処理
        string json = JsonUtility.ToJson(jsonData, true);
        StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + JSON_FILE);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    /// <summary>
    /// 指定した漢字IDに該当する要素番号を取得し、該当要素の倒した数をインクリメントする
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
    public KanjiInfo[] GetKanjiInfoByGradeType(GradeType gradeType)
    {
        switch (gradeType)
        {
            // 小学1年生&2年生の配列を返却
            case GradeType.ALL:
                return kanjiInfos;
            // 小学1年生の配列を返却
            case GradeType.FIRST:
                return GetKanjiInfoByGakunen((int)gradeType);
            // 小学2年生の配列を返却
            case GradeType.SECOND:
                return GetKanjiInfoByGakunen((int)gradeType);
            // 例外処理
            default:
                throw new Exception("引数がEnum:GradeTypeに該当しません");
        }
    }

    void Awake()
    {
        kanjiInfos = ReadJsonData();
    }
}
