using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonController : MonoBehaviour
{
    /// <summary>
    /// �^�C�g���V�[���ɖ߂邽�߂̊֐�
    /// </summary>
    public void LoadTitleScene() 
    {
        SceneManager.LoadScene("Title");
    }
}
