using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    // �����N�ɊY������f��
    private Planet planet;

    // ����̃X�R�A
    private int thisScore;

    /// <summary>
    /// Image, Text�ւ̃����N�̔��f��
    /// �A�j���[�V�����̎��s���s��
    /// </summary>
    private void Start()
    {
        // ����̃X�R�A�E�����N�i���B�f���j��GameManager����擾
        thisScore = GameManager.score;
        planet = GameManager.currentPlanet;

        // Image��Text�𔽉f����
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.SetViewPropertyByPlanet(planet);

        // �A�j���[�V�������s��
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
