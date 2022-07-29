using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetImageController : MonoBehaviour {

    // Resources�t�@�C������Planet Image
    private Sprite planetSprite;

    // �g����Image
    private Image planetImage;

    // �u�Z�Z�N���X�I�v��Text
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
        PlayerPrefs.SetString("thisScore", "11");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // �����N�𔻒f
        ScoreManager scoreManager = new ScoreManager();
        planet = scoreManager.judgeRank(thisScore);
        Debug.Log(thisScore);
        Debug.Log(planet.NameJ);

        // Resouces�t�@�C������X�R�A�ɉ������摜���擾
        planetSprite = Resources.Load<Sprite>("Planets/" + planet.NameE);

        // Text�ɔ��f
        planetNameText.text = planet.NameJ + " �܂� �Ƃ����I";

        // �摜�𔽉f
        planetImage.sprite = planetSprite;
    }



}
