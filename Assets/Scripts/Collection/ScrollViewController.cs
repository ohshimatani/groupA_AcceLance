using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // ボタンセルを表示するためのContent
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCellのPrefabを設定
    [SerializeField] GameObject kanjiCellButton;

    // SecretCellのPrefabを設定
    [SerializeField] GameObject secretCellButton;

    /// <summary>
    /// 漢字データをJSONファイルから取得し、それぞれボタンに反映する
    /// </summary>
    private void Start()
    {
        // 漢字データをJSONファイルから取得
        JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
        KanjiInfo[] kanjiInfoArray = jsonManager.GetKanjiInfoByGradeType(GradeType.ALL);

        // 引数に渡した漢字の情報をもとに、kanjiCellPrefabかsecretCellPrefabのセルを配置
        DeployCellButton(kanjiInfoArray);
    }

    /// <summary>
    /// 引数の情報をもとに、kanjiCellPrefabかsecretCellPrefabのセルを配置
    /// </summary>
    /// <param name="kanjiInfoArray"></param>
    private void DeployCellButton(KanjiInfo[] kanjiInfoArray)
    {
        // 取得した漢字の数だけボタンを生成し、ScrollView内にGrid配置
        foreach (KanjiInfo kanjiInfo in kanjiInfoArray)
        {
            // セットするオブジェクト
            GameObject setObject = secretCellButton;
            if (kanjiInfo.defeat_count > 0)
            {
                setObject = kanjiCellButton;
            }

            // Instantiateするオブジェクト
            GameObject instanceObject = Instantiate(setObject, contentRectTransform);
            instanceObject.GetComponent<CollectionCellButton>().InitStatus(kanjiInfo);
        }
    }
}
