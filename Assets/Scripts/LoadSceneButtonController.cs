using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonController : MonoBehaviour
{
    public void OnClickLoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void OnClickLoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void OnClickLoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void OnClickLoadCollectionScene()
    {
        SceneManager.LoadScene("Collection");
    }

    public void OnClickLoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickLoadParentsScene()
    {
        SceneManager.LoadScene("Parents");
    }
}
