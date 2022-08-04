using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour
{
    // �g����Image
    private Image planetImage;

    // �u�Z�Z �܂� �Ƃ����I�v��Text
    private Text planetNameText;

    // �����N��\������
    private Planet planet;

    // ����̃X�R�A
    private int thisScore;

    void Start()
    {
        // �e��R���|�[�l���g���擾
        planetImage = GetComponent<Image>();
        planetNameText = GameObject.Find("PlanetNameText").GetComponent<Text>();

        // �X�R�A���擾
        // TODO:�O��ʂ���X�R�A���擾����
        PlayerPrefs.SetString("thisScore", "33");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // �����N�𔻒f
        // TODO: �����N�̏�������Game��ʂ��炵����
        ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        planet = scoreManager.JudgeRank(thisScore);

        // Player�̈ʒu�i�A�j���[�V�����̏I�_�j��ResultPlayerController�Ɏw��
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);

        // Text�ɔ��f
        planetNameText.text = planet.nameJ + " �܂� �Ƃ����I";

        // �摜�𔽉f
        planetImage.sprite = planet.sprite;

    }
}
