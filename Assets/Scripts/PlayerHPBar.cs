using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{

    // �t�B�[���h
    private int maxHp = 100;
    private int currentHp;
    public Slider playerHpBar;

    /// <summary>
    /// HP��max��ݒ聕���݂�HP�𖞃^����
    /// </summary>
    void Start()
    {
        playerHpBar = GetComponent<Slider>();
        playerHpBar.maxValue = maxHp;
        currentHp = maxHp;
        playerHpBar.value = currentHp;
    }

    /// <summary>
    /// ��b����10�_���[�W�󂯂鏈��
    /// �i�f�o�b�O�p�̏����B�{�Ԃł͕s�v�j
    /// </summary>
    private float timeleft;
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0.0)
        {
            timeleft = 1.0f;
            ChangePlayerHpBar(10);
        }
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂����̏���
    /// damagePoint�̕������̗͂����炷
    /// </summary>
    /// <param name="damagePoint"></param>
    public void ChangePlayerHpBar(int damagePoint)
    {
        // ���݂�HP��damagePoint�����炷
        currentHp -= damagePoint;

        // ���݂�HP��0��������Ă���ꍇ�͒l��0�Ƃ���
        if (currentHp <= 0)
        {
            playerHpBar.value = 0;
        }
        else
        {
            playerHpBar.value = currentHp;
        }
    }
}
