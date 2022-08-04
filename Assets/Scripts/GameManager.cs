using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���݂̃X�R�A
    public int score { get; private set; } = 0;

    // �X�R�A��\������e�L�X�g�Ƃ��̃R���|�[�l���g
    [SerializeField] GameObject scoreTextObject;
    private ScoreText scoreText;

    private void Start()
    {
        scoreText = scoreTextObject.GetComponent<ScoreText>();
    }

    /// <summary>
    /// �X�R�A�����Z����
    /// </summary>
    public void IncrementScore()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    /// <summary>
    /// �Q�[���I�[�o�[����
    /// </summary>
    public void GameOver()
    {
        // PlayerPrefs�Ɍ��݂̃X�R�A��ǉ�
        PlayerPrefs.SetString("thisScore", score.ToString());

        // ���U���g��ʂɑJ��
        SceneManager.LoadScene("Result");
    }
}
