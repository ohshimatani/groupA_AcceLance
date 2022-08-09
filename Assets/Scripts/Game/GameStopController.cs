using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStopController : MonoBehaviour
{
    // �\��������|�b�v�A�b�v�I�u�W�F�N�g
    [SerializeField] GameObject popUpObject;

    [SerializeField] GameObject stopButton;

    /// <summary>
    /// �ꎞ��~���s��
    /// </summary>
    public void OnClickStopGame()
    {
        SetInteractable(false);
        popUpObject.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// �ꎞ��~��Ԃ���������
    /// </summary>
    public void OnClickUnStopGame()
    {
        SetInteractable(true);
        popUpObject.SetActive(false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// �{�^���̑���\��Ԃ�ύX����
    /// </summary>
    /// <param name="value"></param>
    private void SetInteractable(bool value)
    {
        stopButton.GetComponent<Button>().interactable = value;
    }

    /// <summary>
    /// �^�C�g���ɖ߂�
    /// </summary>
    public void OnClickLoadTitleScene()
    {
        Time.timeScale = 1f;
        StartCoroutine(AsyncLoadTitleScene());
    }
    private IEnumerator AsyncLoadTitleScene()
    {
        var async = SceneManager.LoadSceneAsync("Title");

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(0.5f);
        async.allowSceneActivation = true;
    }
}
