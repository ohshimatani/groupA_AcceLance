using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStopController : MonoBehaviour
{
    // 表示させるポップアップオブジェクト
    [SerializeField] GameObject popUpObject;

    [SerializeField] GameObject stopButton;

    /// <summary>
    /// 一時停止を行う
    /// </summary>
    public void OnClickStopGame()
    {
        SetInteractable(false);
        popUpObject.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// 一時停止状態を解除する
    /// </summary>
    public void OnClickUnStopGame()
    {
        SetInteractable(true);
        popUpObject.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// ボタンの操作可能状態を変更する
    /// </summary>
    /// <param name="value"></param>
    private void SetInteractable(bool value)
    {
        stopButton.GetComponent<Button>().interactable = value;
    }

    /// <summary>
    /// タイトルに戻る
    /// </summary>
    public void OnClickLoadTitleScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(AsyncLoadTitleScene());
    }
    private IEnumerator AsyncLoadTitleScene()
    {
        var async = SceneManager.LoadSceneAsync("Title");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        async.allowSceneActivation = true;
    }
}
