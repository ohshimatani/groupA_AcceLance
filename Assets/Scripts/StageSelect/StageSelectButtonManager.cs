using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageMode
{
    ALL,
    GAKUNEN_1 = 1,
    GAKUNEN_2 = 2
}

public class StageSelectButtonManager : MonoBehaviour
{
    //ステージの学年情報を入れる変数の定義
    public static StageMode stageMode;
    
    /// <summary>
    /// 1年生の漢字ボタン
    /// </summary>
    public void OnClickFirstButton()
    {
        //public staticの変数に1年生ENUMを代入
        stageMode = StageMode.GAKUNEN_1;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 2年生の漢字ボタン
    /// </summary>
    public void OnClickSecondButton()
    {
        //public staticの変数に1年生ENUMを代入
        stageMode = StageMode.GAKUNEN_2;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 1年生と2年生の漢字ボタン
    /// </summary>
    public void OnClickAllButton()
    {
        //public staticの変数にAllのENUMを代入
        stageMode = StageMode.ALL;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// タイトル画面に戻るボタン
    /// </summary>
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

}
