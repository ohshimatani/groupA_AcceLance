using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    SpaceShip spaceShip;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        // �E�E���̓��͒l
        float x = Input.GetAxisRaw("Horizontal");
        // ��E���̓��͒l
        float y = Input.GetAxisRaw("Vertical");

        // �ړ�������������߂�
        // x��y�̓��͒l�𐳋K�����Adirection�ɓn��
        Vector2 direction = new Vector2(x, y).normalized;
        spaceShip.Move(direction);
    }

    /// <summary>
    /// �����蔻�菈��
    /// </summary>
    /// <param name="collision">�ՓˑΏۂ�Collider2D�R���|�[�l���g</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // �Փ˃I�u�W�F�N�g�̃��C���[���̎擾
        string layerName = LayerMask.LayerToName(collider.gameObject.layer);

        // ���C���[����EnemyBullet�̏ꍇ
        if (layerName == "EnemyBullet")
        {
            Destroy(collider.gameObject);
        }

        // ���C���[����EnemyBullet�܂���Enemy�̏ꍇ
        if (layerName == "EnemyBullet" || layerName == "Enemy")
        {
            // ��������
            spaceShip.Explosion();

            // �v���C���[���폜
            Destroy(gameObject);
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
            // �����̍��W����Shot���\�b�h�̈����ɓn��
            spaceShip.Shot(transform);
            // shotDelay�b�҂�
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}