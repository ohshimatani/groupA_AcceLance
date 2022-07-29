using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    /// <summary>
    /// スタートボタン
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }

    /// <summary>
    /// 遊び方ボタン
    /// </summary>
    public void OnClickTutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// 保護者向けボタン
    /// </summary>
    public void OnClickParantsButton()
    {
        SceneManager.LoadScene("Parents");
    }

    /// <summary>
    /// コレクションボタン
    /// </summary>
    public void OnClickCollectionButton()
    {
        SceneManager.LoadScene("Collection");
    }

}
