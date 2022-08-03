using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonManager : MonoBehaviour
{
    /// <summary>
    /// あそぶボタンを押すと、ステージ選択シーンに遷移する
    /// </summary>
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
