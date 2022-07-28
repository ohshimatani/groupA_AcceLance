using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    //画面ごとに表示させるゲームオブジェクトを格納する配列の宣言
    public GameObject[] tutorialObjectArray;

    //次へ進む、戻るための矢印ボタンの宣言
    [SerializeField] GameObject goStepButton;
    [SerializeField] GameObject goBackButton;

    //配列番号と連動させるための変数
    private static int num = 0;

    //配列番号の最大値と最小値
    private int minNum = 0;
    private int maxNum = 4;


    void Start()
    {
        //最初に表示させたいオブジェクトのみ表示、その他を非表示にする
        foreach (GameObject gameObject in tutorialObjectArray)
        {
            gameObject.SetActive(false);
        }
        tutorialObjectArray[0].SetActive(true);

        //進むボタンを表示、戻るボタンを非表示にする
        goStepButton.SetActive(true);
        goBackButton.SetActive(false);
    }

    //進むボタンを押した時の処理
    public void OnClickNextButton()
    {
        //ボタンが押されたらオブジェクトが非表示になる
        tutorialObjectArray[num].SetActive(false);
        
        if(num == minNum)
        {
            goBackButton.SetActive(true);
        }

        //配列番号を加算する
        num += 1;

        //ボタンが押されたらオブジェクトが表示される
        tutorialObjectArray[num].SetActive(true); 

        //配列番号が最大の時（最終ページを表示している時）、進むボタンを非表示にする
        if(num == maxNum)
        {
            goStepButton.SetActive(false);
        }
    }

    //戻るボタンを押したときの処理
    public void OnClickBackButton()
    {
        //ボタンが押されたらオブジェクトが非表示になる
        tutorialObjectArray[num].SetActive(false);

        //配列番号が最大値以外の時（最終ページ以外を表示している時）、進むボタンを表示する
        if (num != maxNum)
        {
            goStepButton.SetActive(true);
        }

        //配列番号を引算する
        num -= 1;

        //ボタンが押されたらオブジェクトが表示される
        tutorialObjectArray[num].SetActive(true);

        //配列番号が最小の時（最初のページを表示しているとき）、戻るボタンを非表示にする
        if (num == minNum)
        {
            goBackButton.SetActive(false);
        }

    }
    


    
}
