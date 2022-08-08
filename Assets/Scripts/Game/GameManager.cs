using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ���݂̃X�R�A
    public static int score { get; private set; }

    // �X�R�A��\������e�L�X�g�Ƃ��̃R���|�[�l���g
    [SerializeField] GameObject scoreTextObject;
    private ScoreText scoreText;

    // �Q�[����ʏ�̘f���摜�𐧌䂷��N���X
    private GamePlanetViewController gamePlanetViewController;

    // �f���̔z��
    private Planet[] planets;

    // ���݂̃����N�i�f���j���L�^
    public static Planet currentPlanet { get; private set; }

    private void Start()
    {
        // �X�R�A��0�ŏ�����
        score = 0;

        scoreText = scoreTextObject.GetComponent<ScoreText>();

        planets = new Planet[] {
            new Planet("Mercury", "����", 0, -5.4f)
            , new Planet("Venus", "����", 4, -4.33f)
            , new Planet("Earth", "�n��", 8, -3f)
            , new Planet("Mars", "�ΐ�", 11, -1.7f)
            , new Planet("Jupiter", "�ؐ�", 16, 0f)
            , new Planet("Saturn", "�y��", 21, 2.73f)
            , new Planet("Uranus", "�V����", 31, 4.87f)
            , new Planet("Neptune", "�C����", 51, 6.35f)
        };

        // ���݂̃����N�̏����l�͐����Ƃ���
        currentPlanet = planets[0];

        // �f���̉摜���Z�b�g����
        gamePlanetViewController = GameObject.Find("GamePlanetViewController").GetComponent<GamePlanetViewController>();
        gamePlanetViewController.InitCurrentPlanetImage(currentPlanet);
    }

    /// <summary>
    /// �X�R�A�����Z����
    /// </summary>
    public void IncrementScore()
    {
        score++;
        scoreText.SetText(score.ToString());

        // �K�v�ɉ����ă����N���X�V����
        UpdateCurrentPlanet();
    }

    /// <summary>
    /// �Q�[���I�[�o�[����
    /// </summary>
    public void GameOver()
    {
        // JSON�ւ̏������ݏ���
        JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
        jsonManager.WriteJsonData();

        // ���U���g��ʂɑJ��
        SceneManager.LoadScene("Result");
    }

    /// <summary>
    /// �X�R�A�����Z���ꂽ�ۂɁA�����ɉ����ă����N���X�V����
    /// </summary>
    private void UpdateCurrentPlanet()
    {
        // �ő�X�R�A������ł���ꍇ�͏������s��Ȃ�
        if (score > planets[planets.Length-1].scoreMin)
        {
            return;
        }

        foreach (Planet planet in planets)
        {
            if (score == planet.scoreMin)
            {
                // �f���̉摜���X�V
                currentPlanet = planet;
                
                // �f���̉摜���`�F���W����
                gamePlanetViewController.ChangeNextPlanet(currentPlanet);

                return;
            }
        }
    }
}
