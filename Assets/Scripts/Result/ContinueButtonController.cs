using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButtonController : MonoBehaviour {

    /// <summary>
    /// Gameシーンに遷移させる関数(Continueボタン押下時に発動)
    /// </summary>
    public void LoadGameScene() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
