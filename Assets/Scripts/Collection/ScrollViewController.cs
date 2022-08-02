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
    /// 【仮置き】80個KanjiCellを生成し、配置
    /// Cellの中身（Text）は1~80の数字
    /// </summary>
    private void Start()
    {
        for (int i = 1; i <= 80; i++)
        {
            GameObject kanjiCell = Instantiate(buttonCell, contentRectTransform);
            kanjiCell.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
