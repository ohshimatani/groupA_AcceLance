using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonManager : MonoBehaviour
{
    /// <summary>
    /// �����ԃ{�^���������ƁA�X�e�[�W�I���V�[���ɑJ�ڂ���
    /// </summary>
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
