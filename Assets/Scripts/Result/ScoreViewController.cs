using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewController : MonoBehaviour {

    private Text thisScoreText;
    private Text bestScoreText;
    [SerializeField] GameObject bestScoreNotation;
    

    private void Start() {
        // �Y��GameObject�����ꂼ��GetComponent
        thisScoreText = GameObject.Find("ThisScoreNumber").GetComponent<Text>();
        bestScoreText = GameObject.Find("BestScoreNumber").GetComponent<Text>();

        ReflectThisScore();
        ReflectBestScore();

        // �x�X�g�X�R�A���ǂ������肵�A
        if (isBestScore()) {
            bestScoreNotation.SetActive(true);
        } else {
            bestScoreNotation.SetActive(false);
        }

    }


    /// <summary>
    /// PlayerPrefs���獡��̃X�R�A���Q�Ƃ��AText�ɔ��f
    /// </summary>
    private void ReflectThisScore() {
        // "thisScore"�L�[���Q�ƁB�L�[�o�^���Ȃ���΃f�t�H���g��"0"���擾
        string thisScore = PlayerPrefs.GetString("thisScore", "0");

        // Text�ɔ��f
        thisScoreText.text = thisScore;
    }


    /// <summary>
    /// PlayerPrefs����x�X�g�X�R�A���Q�Ƃ��AText�ɔ��f
    /// </summary>
    private void ReflectBestScore() {
        // "bestScore"�L�[���Q�ƁB�L�[�o�^���Ȃ���΃f�t�H���g��"0"���擾
        string bestScore = PlayerPrefs.GetString("bestScore", "0");

        // Text�ɔ��f
        bestScoreText.text = bestScore;
    }


    /// <summary>
    /// ����̃X�R�A���x�X�g�X�R�A���ǂ����𔻒�
    /// </summary>
    /// <returns></returns>
    private bool isBestScore() {
        int thisScore = int.Parse(thisScoreText.text);
        int bestScore = int.Parse(bestScoreText.text);

        if (thisScore >= bestScore) {
            return true;
        } else {
            return false;
        }
    }

}
