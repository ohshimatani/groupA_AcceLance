using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // Contentをアタッチ
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCellのPrefabを設定
    [SerializeField] GameObject buttonCell;

    /// <summary>
    /// 漢字データをJSONファイルから取得し、それぞれボタンのTextに反映する。
    /// </summary>
    private void Start()
    {
        // 漢字データをJSONファイルから取得
        JsonManager jsonManager = new JsonManager();
        KanjiInfo[] kanjiInfo = jsonManager.GetKanjiInfoByStageMode(StageMode.ALL);

        DisposeKanjiCell(kanjiInfo);
    }

    private void DisposeKanjiCell(KanjiInfo[] kanjiInfo)
    {
        // 取得した漢字の数だけKanjiCellを生成し、ScrollView内にGrid配置
        for (int i = 0; i < kanjiInfo.Length; i++)
        {
            GameObject kanjiCell = Instantiate(buttonCell, contentRectTransform);
            kanjiCell.GetComponentInChildren<Text>().text = kanjiInfo[i].kanji;
            
        }
    }
}
