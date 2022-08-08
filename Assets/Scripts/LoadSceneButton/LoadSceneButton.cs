using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void OnClickLoadTitleScene()
    {
        StartCoroutine(AsyncSceneLoad("Title"));
    }

    public void OnClickLoadStageSelectScene()
    {
        StartCoroutine(AsyncSceneLoad("StageSelect"));
    }

    public void OnClickLoadTutorialScene()
    {
        StartCoroutine(AsyncSceneLoad("Tutorial"));
    }

    public void OnClickLoadCollectionScene()
    {
        StartCoroutine(AsyncSceneLoad("Collection"));
    }

    public void OnClickLoadGameScene()
    {
        StartCoroutine(AsyncSceneLoad("Game"));
    }

    public void OnClickLoadParentsScene()
    {
        StartCoroutine(AsyncSceneLoad("Parents"));
    }

    /// <summary>
    /// É{É^ÉìÇÃå¯â âπÇìríÜÇ≈ìrêÿÇÍÇ≥ÇπÇ»Ç¢ÇΩÇﬂÇ…ÉVÅ[Éìì«Ç›çûÇ›Ç0.5ïbíxÇÍÇ≥ÇπÇÈ
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator AsyncSceneLoad(string sceneName)
    {
        var async = SceneManager.LoadSceneAsync(sceneName);

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        async.allowSceneActivation = true;
    }
}
