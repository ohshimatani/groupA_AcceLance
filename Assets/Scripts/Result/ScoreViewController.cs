using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewController : MonoBehaviour {

    // ����̃X�R�A��Text
    private Text thisScoreText;
    // �x�X�g�X�R�A��Text
    private Text bestScoreText;
    // �u�������L�낭�I�v�̕\��Text
    [SerializeField] GameObject bestScoreNotation;
    

    private void Start() {
        // �Y��GameObject�����ꂼ��GetComponent
        thisScoreText = GameObject.Find("ThisScoreNumber").GetComponent<Text>();
        bestScoreText = GameObject.Find("BestScoreNumber").GetComponent<Text>();

        // ���ꂼ��̃L�[���Q�ƁB�L�[�o�^���Ȃ���΃f�t�H���g��"0"���擾
        string thisScore = PlayerPrefs.GetString("thisScore", "0");
        string bestScore = PlayerPrefs.GetString("bestScore", "0");

        // Text�ɔ��f
        thisScoreText.text = thisScore;
        bestScoreText.text = bestScore;

        // �x�X�g�X�R�A���ǂ������肵�ANotation�̕\��/��\����I��
        if (isBestScore()) {
            // ����̃X�R�A���x�X�g�X�R�A�Ȃ�APlayerPrefs��bestScore���X�V����
            PlayerPrefs.SetString("bestScore", thisScoreText.text);
            PlayerPrefs.Save();
            bestScoreNotation.SetActive(true);
        } else {
            bestScoreNotation.SetActive(false);
        }

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
