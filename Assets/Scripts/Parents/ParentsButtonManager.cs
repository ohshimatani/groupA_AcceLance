using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ParentsButtonManager : MonoBehaviour
{
    /// <summary>
    /// 遊び方ボタン
    /// </summary>
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
