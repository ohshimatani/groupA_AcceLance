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
        SceneManager.LoadScene("SelectStage");
    }

    /// <summary>
    /// �V�ѕ��{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickTutorialButton()
    {
        //�����т�����ʂ�Scene���ɍ��킹��
        SceneManager.LoadScene("Tutorial");
    }

    /// <summary>
    /// �ی�Ҍ����{�^��
    /// </summary>
    /// <returns></returns>
    public void OnClickParantsButton()
    {
        //�ی�Ҍ�����ʂ�Scene���ɍ��킹��i���͉��u���j
        SceneManager.LoadScene("Parents");
    }

}
