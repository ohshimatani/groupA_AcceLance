using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStopButtonController : MonoBehaviour
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
        SceneManager.LoadScene("Title");
    }
}
