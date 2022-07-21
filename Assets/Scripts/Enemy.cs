using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    SpaceShip spaceShip;

    /// <summary>
    /// �Q�[���X�^�[�g���̏���
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        // ��ʏォ�牺�Ɉړ�������
        spaceShip.Move(transform.up * -1);
        // �e�̔��ˏ��������s
        StartCoroutine("Shot");
    }

    /// <summary>
    /// �����蔻�菈��
    /// </summary>
    /// <param name="collider">�ՓˑΏۂ�Collider2D�R���|�[�l���g</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // �Փ˃I�u�W�F�N�g�̃��C���[���̎擾
        string layerName = LayerMask.LayerToName(collider.gameObject.layer);

        // ���C���[����PlayerBullet�̏ꍇ
        if (layerName == "PlayerBullet")
        {
            // �_���[�W����
            spaceShip.damage();

            // �e�̍폜
            Destroy(collider.gameObject);

            // HP��0�ɂȂ������̏���
            if (spaceShip.getHp() <= 0)
            {
                // ��������
                spaceShip.Explosion();

                // ���g�i�G�l�~�[�j���폜
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// �e�̔��ˏ����i�R���[�`���j
    /// </summary>
    /// <returns></returns>
    IEnumerator Shot()
    {
        while (true)
        {
            // �q�v�f��S�ďK������
            for (int i = 0; i < transform.childCount; i++)
            {
                // �q�v�f��S�Ď擾����
                // TODO: �����̒e�𔭎˂����邩�ۂ��ɂ���ď�����ς���
                Transform shotPosition = transform.GetChild(i);

                // �e���v���C��[�Ɠ����ʒu/�p�x�Ő���
                spaceShip.Shot(shotPosition);
            }

            // shotDelay�b�҂�
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
