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
        Destroy(gameObject);
    }
}
