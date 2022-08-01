using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // Contentをアタッチ
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCellのPrefabを設定
    [SerializeField] GameObject kanjiCellPrefab;

    // SecretCellのPrefabを設定
    [SerializeField] GameObject secretCellPrefab;

    /// <summary>
    /// 漢字データをJSONファイルから取得し、それぞれボタンのTextに反映する。
    /// </summary>
    private void Start()
    {
        // 漢字データをJSONファイルから取得
        JsonManager jsonManager = new JsonManager();
        Debug.Log(StageMode.ALL);
        KanjiInfo[] kanjiInfo = jsonManager.GetKanjiInfoByStageMode(StageMode.ALL);

        Debug.Log(kanjiInfo.Length);
        // 引数に渡した漢字の情報をもとに、漢字のセル or ハテナのセルを配置
        DisposeKanjiCell(kanjiInfo);
    }

    /// <summary>
    /// 引数の情報をもとに、漢字のセル or ハテナのセルを配置する。
    /// </summary>
    /// <param name="kanjiInfo"></param>
    private void DisposeKanjiCell(KanjiInfo[] kanjiInfo)
    {
        // 取得した漢字の数だけKanjiCellを生成し、ScrollView内にGrid配置
        for (int i = 0; i < kanjiInfo.Length; i++)
        {
            if (kanjiInfo[i].defeat_count >= 1)
            {
                // 倒された数が１より大きいとき、その漢字Cellを表示
                GameObject kanjiCell = Instantiate(kanjiCellPrefab, contentRectTransform);
                kanjiCell.GetComponentInChildren<Text>().text = kanjiInfo[i].kanji;
            } else
            {
                // 倒されていない漢字のとき、ハテナを表示
                Instantiate(secretCellPrefab, contentRectTransform);
            }
        }
    }
}
