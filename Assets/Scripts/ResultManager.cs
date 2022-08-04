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
        // �X�R�A���擾
        // TODO:�O��ʂ���X�R�A���擾����
        PlayerPrefs.SetString("thisScore", "33");
        thisScore = int.Parse(PlayerPrefs.GetString("thisScore", "0"));

        // �����N�𔻒f
        // TODO: �����N�̏�������Game��ʂ��炵����
        ScoreManager scoreManager = new ScoreManager();
        planet = scoreManager.JudgeRank(thisScore);

        // Image��Text�𔽉f����
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.ReflectView(planet);

        // �A�j���[�V�������s��
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
