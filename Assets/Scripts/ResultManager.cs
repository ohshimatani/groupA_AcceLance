using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    private const string BEST_SCORE_PREFS_KEY = "bestScore";

    private void Start()
    {
        // ����̃X�R�A�ƍ��܂ł̍ō��X�R�A���擾����
        int thisScore = GameManager.score;
        int bestScore = PlayerPrefs.GetInt(BEST_SCORE_PREFS_KEY, 0);

        // ����̓��B�����N�i�f���j���擾
        Planet planet = GameManager.currentPlanet;

        // �X�R�A�Ɋւ���Text�A�����N��Image�𔽉f����
        ResultViewController resultViewController = GameObject.Find("ResultViewController").GetComponent<ResultViewController>();
        resultViewController.SetThisScoreText(thisScore.ToString());
        resultViewController.SetBestScoreText(bestScore.ToString());
        resultViewController.SetViewPropertyByPlanet(planet);

        // �ō��X�R�A�̍X�V���ꂽ�ꍇ�AbestScore���㏑�����A�u�������L�낭�I�v����ʏ�ɕ\������
        if (thisScore > bestScore)
        {
            // PlayerPrefs���X�V����ѕۑ�
            PlayerPrefs.SetInt(BEST_SCORE_PREFS_KEY, thisScore);
            PlayerPrefs.Save();

            resultViewController.SetActiveBestScoreNotation(true);
        }
        else
        {
            resultViewController.SetActiveBestScoreNotation(false);
        }

        // �A�j���[�V�������s��
        ResultPlayerAnimator resultPlayerAnimator = GameObject.Find("Player").GetComponent<ResultPlayerAnimator>();
        resultPlayerAnimator.Animate(planet.positionX);
    }
}
