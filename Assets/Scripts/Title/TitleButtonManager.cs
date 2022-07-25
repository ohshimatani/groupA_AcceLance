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
        SceneManager.LoadScene("SelectStage");
    }

    /// <summary>
    /// 遊び方ボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickTutorialButton()
    {
        //遊び方画面のScene名に合わせる（今は仮置き）
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// 保護者向けボタン
    /// </summary>
    /// <returns></returns>
    public void OnClickParantsButton()
    {
        //保護者向け画面のScene名に合わせる（今は仮置き）
        SceneManager.LoadScene("Parents");
    }

}
