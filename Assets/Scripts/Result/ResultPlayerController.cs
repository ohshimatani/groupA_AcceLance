using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/// <summary>
/// ���U���g��ʂɒu����v���C���[�i���P�b�g�j�̃A�j���[�V�����𐧌䂷�邽�߂̃N���X
/// </summary>
public class ResultPlayerController : MonoBehaviour
{
    // �v���C���[�̃|�W�V�����iPlanetImageController����set�����j
    private float playerPosition = -5.4f;

    // �A�j���[�V�����̎��ԁi�b�j
    private float duration = 2f;

    /// <summary>
    /// Player�������N�ɉ����ăA�j���[�V����������
    /// </summary>
    public void Animate()
    {
        this.transform.DOMoveX(playerPosition, duration);
    }

    /// <summary>
    /// playerPosition�̃A�N�Z�b�T
    /// </summary>
    public float PlayerPosition
    {
        get
        {
            return playerPosition;
        }
        set
        {
            playerPosition = value;
        }
    }
}
