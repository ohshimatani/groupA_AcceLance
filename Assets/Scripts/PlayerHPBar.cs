using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{

    // �ő�̗�
    private int maxHp;

    // HP�o�[�̕`��p�X���C�_�[
    private Slider playerHpBar;

    /// <summary>
    /// HP�o�[�֘A�̏����ݒ�
    /// </summary>
    public void InitializedHpBar(int hp)
    {
        maxHp = hp;
        playerHpBar = GetComponent<Slider>();
        playerHpBar.maxValue = maxHp;
        playerHpBar.value = maxHp;
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂����̏���
    /// damagePoint�̕������̗͂����炷
    /// </summary>
    /// <param name="damagePoint"></param>
    public void SetPlayerHpBar(int hp)
    {
        playerHpBar.value = hp;
    }
}
