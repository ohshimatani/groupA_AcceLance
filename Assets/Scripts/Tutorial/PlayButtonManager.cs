using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �����ԃ{�^���������ƁA�X�e�[�W�I����ʂɑJ�ڂ���
/// </summary>
public class PlayButtonManager: MonoBehaviour
{
    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("StageSelect");
    }
}
