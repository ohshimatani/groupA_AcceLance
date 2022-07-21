using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour {

    // �t�B�[���h
    private int maxHp = 100;
    public Slider playerHpBar;

    /// <summary>
    /// HP��max��ݒ聕���݂�HP�𖞃^����
    /// </summary>
    void Start() {
        playerHpBar = GetComponent<Slider>();
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = maxHp;
    }

    /// <summary>
    /// ��b����10�_���[�W�󂯂鏈��
    /// �i�f�o�b�O�p�̏����B�{�Ԃł͕s�v�j
    /// </summary>
    private float timeleft;
    void Update() {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0) {
            timeleft = 1.0f;
            ChangePlayerHpBar(10);
        }
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂����̏���
    /// damagePoint�̕������̗͂����炷
    /// </summary>
    /// <param name="damagePoint"></param>
    public void ChangePlayerHpBar(int damagePoint) {
        if (playerHpBar.value <= damagePoint) {
            playerHpBar.value = 0;
            // �Q�[���I�[�o�[����


        } else {
            playerHpBar.value -= damagePoint;
        }
        
    }
}
