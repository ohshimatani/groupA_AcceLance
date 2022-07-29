using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    /// <summary>
    /// �X�^�[�g�{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }

    /// <summary>
    /// �V�ѕ��{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickTutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// �ی�Ҍ����{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickParantsButton()
    {
        SceneManager.LoadScene("Parents");
    }

    /// <summary>
    /// �R���N�V�����{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickCollectionButton()
    {
        SceneManager.LoadScene("Collection");
    }

}
