using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButtonController : MonoBehaviour {

    /// <summary>
    /// Game�V�[���ɑJ�ڂ�����֐�(Continue�{�^���������ɔ���)
    /// </summary>
    public void LoadGameScene() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
