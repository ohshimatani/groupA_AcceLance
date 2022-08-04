using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonController : MonoBehaviour {

    /// <summary>
    /// Titleシーンに遷移させる関数(Exitボタン押下時に発動)
    /// </summary>
    public void LoadTitleScene() {
        // [TODO]Titleシーンができ次第、第一引数を反映させる
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
