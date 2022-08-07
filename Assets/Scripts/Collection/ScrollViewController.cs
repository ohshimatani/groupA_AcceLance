using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    JsonManager jsonManager;

    // ボタンセルを表示するためのContent
    [SerializeField] GameObject content;

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
        jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();

        // 引数に渡した漢字の情報をもとに、kanjiCellPrefabかsecretCellPrefabのセルを配置
        DeployCellButton(GradeType.ALL);
    }

    /// <summary>
    /// 引数の情報をもとに、kanjiCellPrefabかsecretCellPrefabのセルを配置
    /// </summary>
    /// <param name="kanjiInfos"></param>
    public void DeployCellButton(GradeType gradeType)
    {
        // 描画を一度リフレッシュする（これをしないと切り替えても漢字セルが残り続ける）
        RefleshView();

        // 指定された学年の漢字JSONを取得
        KanjiInfo[] kanjiInfos = jsonManager.GetKanjiInfoByGradeType(gradeType);

        // 取得した漢字の数だけボタンを生成し、ScrollView内にGrid配置
        foreach (KanjiInfo kanjiInfo in kanjiInfos)
        {
            // セットするオブジェクト
            GameObject setObject = secretCellButton;
            if (kanjiInfo.defeat_count > 0)
            {
                setObject = kanjiCellButton;
            }

            // Instantiateするオブジェクト
            GameObject instanceObject = Instantiate(setObject, content.GetComponent<RectTransform>());
            instanceObject.GetComponent<CollectionCellButton>().InitStatus(kanjiInfo);
        }
    }

    /// <summary>
    /// 描画をリフレッシュする
    /// </summary>
    private void RefleshView()
    {
        // contentの配下にある子オブジェクトを全て削除する
        foreach (Transform child in content.transform)
        {
            Destroy(child.gameObject);
        }

        // スクロール位置を一番上に戻す
        gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;
    }
}
