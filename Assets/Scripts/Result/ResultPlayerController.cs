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
    private float playerPosition;

    private void Start()
    {
        ScoreManager scoreManager = new ScoreManager();
        ScoreManager
        this.transform.DOMoveX(-1.7f, 2f);
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
