using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour {

    /// <summary>
    /// Title�V�[���ɑJ�ڂ�����֐�(Exit�{�^���������ɔ���)
    /// </summary>
    public void LoadTitleScene() {
        // [TODO]Title�V�[�����ł�����A�������𔽉f������
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
