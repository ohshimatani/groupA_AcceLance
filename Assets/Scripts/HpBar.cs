using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    // �ő�̗�
    private int maxHp;

    // HP�o�[�̕`��p�X���C�_�[
    private Slider hpBar;

    /// <summary>
    /// HP�o�[�֘A�̏����ݒ�
    /// </summary>
    public void InitializedHpBar(int hp)
    {
        maxHp = hp;
        hpBar = GetComponent<Slider>();
        hpBar.maxValue = maxHp;
        hpBar.value = maxHp;
    }

    /// <summary>
    /// �v���C���[���_���[�W���󂯂����̏���
    /// damagePoint�̕������̗͂����炷
    /// </summary>
    /// <param name="damagePoint"></param>
    public void SetHpBarValue(int hp)
    {
        hpBar.value = hp;
    }
}
