using System.Collections;
using System.Collections.Generic;


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

    /// <summary>
    /// Equalsがtrueを返すときに同じ値を返す
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return this.kanji_id;
    }

    public override string ToString()
    {
        return "Info: " + kanji_id + " " + kanji + " " + defeat_count;
    }
}
