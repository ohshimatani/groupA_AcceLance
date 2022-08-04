using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2D�R���|�[�l���g��K�{�ɂ���
[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{
    // �e�̈ړ��X�s�[�h
    public int speed = 10;

    // �Q�[���I�u�W�F�N�g��������폜����܂ł̎���
    public float lifeTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ���[�J�����W��Y�������Ɉړ�����
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
    }
}
