using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour
{
    // �g����Image
    [SerializeField] Image planetImage;

    // �u�Z�Z �܂� �Ƃ����I�v��Text
    [SerializeField] Text planetNameText;

    // ����������
    [SerializeField] Text thisScoreText;

    // �ō��X�R�A
    [SerializeField] Text bestScoreText;

    // �u�������L�낭�I�v�̕\��Text
    [SerializeField] GameObject bestScoreNotation;

    /// <summary>
    /// ����̃X�R�A���e�L�X�g�ɕ\��
    /// </summary>
    /// <param name="thisScore"></param>
    public void SetThisScoreText(string thisScore)
    {
        thisScoreText.text = thisScore;
    }

    /// <summary>
    /// ���܂ł̍ō��X�R�A���e�L�X�g�ɕ\��
    /// </summary>
    /// <param name="bestScore"></param>
    public void SetBestScoreText(string bestScore)
    {
        bestScoreText.text = bestScore;
    }

    /// <summary>
    /// �u�������L�낭�I�v��\�����邩�ۂ�
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActiveBestScoreNotation(bool isActive)
    {
        bestScoreNotation.SetActive(isActive);
    }

    /// <summary>
    /// Image��Text�𔽉f������
    /// </summary>
    /// <param name="planet"></param>
    public void SetViewPropertyByPlanet(Planet planet)
    {
        // Text�ɔ��f
        planetNameText.text = planet.nameJ + " �܂� �Ƃ����I";

        // �摜�𔽉f
        planetImage.sprite = planet.sprite;
    }
}
