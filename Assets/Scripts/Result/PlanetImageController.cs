using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetImageController : MonoBehaviour {

    // �g����Image
    private Image planetImage;

    // �u�Z�Z �܂� �Ƃ����I�v��Text
    private Text planetNameText;

    // �����N��\������
    private Planet planet;

    // ����̃X�R�A
    private int thisScore;

    void Start() {
        // �e��R���|�[�l���g���擾
        planetImage = GetComponent<Image>();
        planetNameText = GameObject.Find("PlanetNameText").GetComponent<Text>();

        // �X�R�A���擾
        // TODO:�O��ʂ���X�R�A���擾����
        //PlayerPrefs.SetString("thisScore", "11");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // �����N�𔻒f
        ScoreManager scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        planet = scoreManager.JudgeRank(thisScore);

        // Text�ɔ��f
        planetNameText.text = planet.NameJ + " �܂� �Ƃ����I";

        // �摜�𔽉f
        planetImage.sprite = planet.Sprite;
    }



}
