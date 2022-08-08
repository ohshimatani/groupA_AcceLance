using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip boomSE;
    
    /// <summary>
    /// �A�j���[�V�����̏I������
    /// </summary>
    void OnAnimationFinish()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(boomSE);
        Destroy(gameObject);
    }
}
