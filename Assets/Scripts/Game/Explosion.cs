using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{   
    /// <summary>
    /// �A�j���[�V�����̏I������
    /// </summary>
    void OnAnimationFinish()
    {
        // �I�u�W�F�N�g�̍폜
        Destroy(gameObject);
    }
}
