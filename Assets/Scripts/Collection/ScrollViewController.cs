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
        JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
        KanjiInfo[] kanjiInfoArray = jsonManager.GetKanjiInfoByStageMode(StageMode.ALL);

        // 引数に渡した漢字の情報をもとに、漢字のセル or ハテナのセルを配置
        ArrangementKanjiCell(kanjiInfoArray);
    }


    /// <summary>
    /// 引数の情報をもとに、漢字のセル or ハテナのセルを配置する。
    /// </summary>
    /// <param name="kanjiInfoArray"></param>
    private void ArrangementKanjiCell(KanjiInfo[] kanjiInfoArray)
    {
        // 取得した漢字の数だけKanjiCellを生成し、ScrollView内にGrid配置
        for (int i = 0; i < kanjiInfoArray.Length; i++)
        {
            if (kanjiInfoArray[i].defeat_count >= 1)
            {
                // 倒された数が１より大きいとき、その漢字Cellを表示
                GameObject kanjiCell = Instantiate(kanjiCellPrefab, contentRectTransform);

                // セル内の情報を反映させるメソッドを発動
                kanjiCell.GetComponent<KanjiCell>().InitKanjiStatus(kanjiInfoArray[i]);
            } else
            {
                // 倒されていない漢字のとき、ハテナを表示
                GameObject secretCell = Instantiate(secretCellPrefab, contentRectTransform);

                // セル内の情報を反映させるメソッドを発動
                secretCell.GetComponent<SecretCell>().InitKanjiStatus(kanjiInfoArray[i]);
            }
        }
    }
}
