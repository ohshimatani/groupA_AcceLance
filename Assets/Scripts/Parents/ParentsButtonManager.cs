using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ParentsButtonManager : MonoBehaviour
{
    /// <summary>
    /// タイトルに戻るボタン
    /// </summary>
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
