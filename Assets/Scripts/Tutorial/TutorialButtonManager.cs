using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonManager: MonoBehaviour
{
    // ページごとに表示させるゲームオブジェクトを格納する配列の宣言
    [SerializeField] GameObject[] pageObjects;

    // 次へ進む、戻るための矢印ボタンの宣言
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject prevButton;

    // 配列番号とページを連動させるための変数
    private static int pageNum;

    // ページ数の最大値と最小値
    private const int MIN_PAGE_NUM = 0;
    private const int MAX_PAGE_NUM = 6;


    void Start()
    {
        pageNum = 0;

        // 最初に表示させたいオブジェクトのみ表示、その他を非表示にする
        foreach (GameObject gameObject in pageObjects)
        {
            gameObject.SetActive(false);
        }
        pageObjects[MIN_PAGE_NUM].SetActive(true);

        // 進むボタンを表示、戻るボタンを非表示にする
        nextButton.SetActive(true);
        prevButton.SetActive(false);
    }

    /// <summary>
    /// 進むボタン、戻るボタンについて、表示・非表示を制御するメソッド
    /// </summary>
    private void SetButtonActive()
    {
        // 最初のページを表示した時は戻るボタンを非表示にする
        if (pageNum == MIN_PAGE_NUM)
        {
            prevButton.SetActive(false);
        }
        // 最後のページを表示した時は進むボタンを非表示にする
        else if (pageNum == MAX_PAGE_NUM)
        {
            nextButton.SetActive(false);
        }
        // 最後のページと最後のページ以外の時は、進むボタンと戻るボタンを表示する
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    /// <summary>
    /// ページ番号を変更し、ページごとのオブジェクトの表示・非表示を切り替えるメソッド
    /// </summary>
    /// <param name="buttonType"></param>
    private void SetPageObject(string buttonType)
    {
        // 既に表示されていたオブジェクトを非表示にする
        pageObjects[pageNum].SetActive(false);

        // ページを戻した時にページ番号を -1 する
        if ("prev".Equals(buttonType))
        {
            pageNum--;
        }

        // ページを進めた時にページ番号を+1 する
        if ("next".Equals(buttonType))
        {
            pageNum++;
        }

        // 次に表示したいオブジェクトが表示される
        pageObjects[pageNum].SetActive(true);
    }



    /// <summary>
    /// 進むボタンを押した時の処理
    /// </summary>
    public void OnClickNextButton()
    {
        SetPageObject("next");
        SetButtonActive();
    }

    /// <summary>
    /// 戻るボタンを押したときの処理
    /// </summary>
    public void OnClickPrevButton()
    {
        SetPageObject("prev");
        SetButtonActive();
    }

}
