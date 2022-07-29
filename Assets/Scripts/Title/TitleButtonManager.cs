using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    /// <summary>
    /// スタートボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }

    /// <summary>
    /// 遊び方ボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickTutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// 保護者向けボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickParantsButton()
    {
        SceneManager.LoadScene("Parents");
    }

    /// <summary>
    /// コレクションボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickCollectionButton()
    {
        SceneManager.LoadScene("Collection");
    }

}
