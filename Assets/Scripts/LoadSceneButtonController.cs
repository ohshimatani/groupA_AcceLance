using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonController : BaseButtonController
{
    protected override void OnClick(string objectName)
    {
        Debug.Log("objectName" + objectName);
        switch (objectName)
        {
            case "StartButton":
                LoadStageSelectScene();
                break;
            case "TutorialButton":
                LoadTutorialScene();
                break;
            case "CollectionButton":
                LoadCollectionScene();
                break;
            case "ParentsButton":
                LoadParentsScene();
                break;
            default:
                throw new System.Exception("implement‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
        }
    }

    private void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    private void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    private void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    private void LoadCollectionScene()
    {
        SceneManager.LoadScene("Collection");
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    private void LoadParentsScene()
    {
        SceneManager.LoadScene("Parents");
    }
}
