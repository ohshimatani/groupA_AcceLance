using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ParentsButtonManager : MonoBehaviour
{
    /// <summary>
    /// �^�C�g���ɖ߂�{�^��
    /// </summary>
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
