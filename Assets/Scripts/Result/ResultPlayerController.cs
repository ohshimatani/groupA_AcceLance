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
    private float playerPositionX;

    // �A�j���[�V�����̎��ԁi�b�j
    private const float DURATION = 2f;

    private void Start()
    {
        Transform transForm = GameObject.Find("Player").transform;
        playerPositionX = transForm.position.x;
    }

    /// <summary>
    /// Player�������N�ɉ����ăA�j���[�V����������
    /// </summary>
    public void Animate()
    {
        this.transform.DOMoveX(playerPositionX, DURATION);
    }

    /// <summary>
    /// playerPosition�̃A�N�Z�b�T
    /// </summary>
    public float PlayerPositionX
    {
        get
        {
            return playerPositionX;
        }
        set
        {
            playerPositionX = value;
        }
    }
}
