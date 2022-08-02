using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    /// <summary>
    /// タイトルシーンに戻るための関数
    /// </summary>
    public void LoadTitleScene() 
    {
        SceneManager.LoadScene("Title");
    }
}
