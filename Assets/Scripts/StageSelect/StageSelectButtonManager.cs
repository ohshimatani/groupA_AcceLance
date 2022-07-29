using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum StageMode
{
    ALL,
    GAKUNEN_1 = 1,
    GAKUNEN_2 = 2
}

public class StageSelectButtonManager : MonoBehaviour
{
    //�X�e�[�W�̊w�N��������ϐ��̒�`
    public static StageMode stageMode;
    
    /// <summary>
    /// 1�N���̊����{�^��
    /// </summary>
    public void OnClickFirstButton()
    {
        //public static�̕ϐ���1�N��ENUM����
        stageMode = StageMode.GAKUNEN_1;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 2�N���̊����{�^��
    /// </summary>
    public void OnClickSecondButton()
    {
        //public static�̕ϐ���1�N��ENUM����
        stageMode = StageMode.GAKUNEN_2;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// 1�N����2�N���̊����{�^��
    /// </summary>
    public void OnClickAllButton()
    {
        //public static�̕ϐ���All��ENUM����
        stageMode = StageMode.ALL;
        SceneManager.LoadScene("Game");
    }

    /// <summary>
    /// �^�C�g����ʂɖ߂�{�^��
    /// </summary>
    public void OnClickTitleButton()
    {
        SceneManager.LoadScene("Title");
    }

}
