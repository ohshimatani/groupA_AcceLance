using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// あそぶボタンを押すと、ステージ選択画面に遷移する
/// </summary>
public class PlayButtonManager: MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
