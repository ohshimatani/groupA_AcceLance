using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonManager : MonoBehaviour
{
    /// <summary>
    /// �X�^�[�g�{�^��
    /// </summary>
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("StageSelect");
    }

    /// <summary>
    /// �V�ѕ��{�^��
    /// </summary>
    public void OnClickTutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// �ی�Ҍ����{�^��
    /// </summary>
    public void OnClickParantsButton()
    {
        SceneManager.LoadScene("Parents");
    }

    /// <summary>
    /// �R���N�V�����{�^��
    /// </summary>
    public void OnClickCollectionButton()
    {
        SceneManager.LoadScene("Collection");
    }

}
