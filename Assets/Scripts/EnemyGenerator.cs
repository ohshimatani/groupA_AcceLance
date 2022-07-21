using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    //�X�|�[���̊J�n����
    [SerializeField] float startTime = 1f;
    //�X�|�[���̎��ԊԊu
    [SerializeField] float interval = 6f;

    /// <summary>
    /// �Q�[���X�^�[�g���̏���
    /// </summary>
    void Start()
    {
        // �J��Ԃ��֐������s����ispawn��1�b���6�b���݂Ŏ��s�j
        InvokeRepeating("Spawn", startTime, interval);
    }

    /// <summary>
    /// �G�I�u�W�F�N�g�̐���
    /// </summary>
    void Spawn()
    {
        // �����ʒu�ix���j�������_���ɐݒ�
        Vector3 spawnPosition = new Vector3(
            Random.Range(-9.0f, 9.0f)// ��������x���͈̔́B����̃Q�[����ʂ̉����̍��W�ɑΉ�
            , transform.position.y
            , transform.position.z
        );

        //enemy���C���X�^���X������
        Instantiate(enemyPrefab// �����������
            , spawnPosition// ��������ꏊ
            , transform.rotation// �������̌���
        );
    }
}
