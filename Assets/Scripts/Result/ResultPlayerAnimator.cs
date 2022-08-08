using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


/// <summary>
/// ���U���g��ʂɒu����v���C���[�i���P�b�g�j�̃A�j���[�V�����𐧌䂷�邽�߂̃N���X
/// </summary>
public class ResultPlayerAnimator : MonoBehaviour
{
    // �A�j���[�V�����̎��ԁi�b�j
    private const float DURATION = 2f;

    /// <summary>
    /// �����Ŏw�肳�ꂽ�ꏊ�܂ŃA�j���[�V������������
    /// </summary>
    /// <param name="positionX"></param>
    public void Animate(float positionX)
    {
        transform.DOMoveX(positionX, DURATION);
    }

}
