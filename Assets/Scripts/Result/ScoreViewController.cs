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
        string thisScore = PlayerPrefs.GetString("thisScore", "22");

        // Text�ɔ��f
        thisScoreText.text = thisScore;
    }

    /// <summary>
    /// PlayerPrefs����x�X�g�X�R�A���Q�Ƃ��AText�ɔ��f
    /// </summary>
    private void ReflectBestScore() {
        // "bestScore"�L�[���Q�ƁB�L�[�o�^���Ȃ���΃f�t�H���g��"0"���擾
        string bestScore = PlayerPrefs.GetString("bestScore", "111");

        // Text�ɔ��f
        bestScoreText.text = bestScore;
    }
}
