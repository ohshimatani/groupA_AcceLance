using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidbody2D�����Animator�R���|�[�l���g��K�{�ɂ���
[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]

/// <summary>
/// �v���C��[�ƓG�I�u�W�F�N�g�̋��ʗv�f���L�ڂ���N���X
/// </summary>
public class SpaceShip : MonoBehaviour
{
    // �I�u�W�F�N�g�̈ړ��X�s�[�h���i�[����ϐ�
    public float speed;

    // �v���C���[�E�G��HP
    [SerializeField] int hp;

    // �_���[�W�|�C���g
    private const int DAMAGE_POINT = 1;

    // �e�����Ԋu���i�[����ϐ�
    public float shotDelay;

    // �e�̃v���n�u���i�[����ϐ�
    public GameObject bullet;

    // Rigidbody2D�R���|�[�l���g���i�[����ϐ�
    private Rigidbody2D rigidBody;

    // ������Prefab
    public GameObject explosion;

    // �A�j���[�^�[�R���|�[�l���g
    private Animator animator;

    /// <summary>
    /// �Q�[���N�����̏���
    /// </summary>
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// �����̏���
    /// </summary>
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    /// <summary>
    /// �_���[�W�����i1���_���[�W��H�炤�j
    /// </summary>
    public void damage()
    {
        hp -= DAMAGE_POINT;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public int getHp()
    {
        return hp;
    }

    /// <summary>
    /// Start�֐�
    /// </summary>
    /// <param name="origin">�I�u�W�F�N�g�̍��W</param>
    public void Shot(Transform origin)
    {
        // �e������origin�Ɠ����ʒu/�p�x�Ő���
        Instantiate(bullet, origin.position, origin.rotation);
    }

    /// <summary>
    /// �I�u�W�F�N�g�̈ړ�����
    /// </summary>
    /// <param name="direction">�I�u�W�F�N�g�̈ړ�����</param>
    public void Move(Vector2 direction)
    {
        // Rigidbody2D�R���|�[�l���g��velocity�Ɉړ������ƈړ����x���|�����l��n��
        rigidBody.velocity = direction * speed;
    }
}
