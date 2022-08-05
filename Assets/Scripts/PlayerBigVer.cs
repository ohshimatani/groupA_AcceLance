using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBigVer : MonoBehaviour
{
    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    SpaceShip spaceShip;

    // �X�N���v�gPlayerHpBar�̃R���|�[�l���g���i�[����ϐ�
    PlayerHpBar playerHpBar;

    // Start is called before the first frame update
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();

        // HP�o�[�̏����ݒ�
        playerHpBar = GameObject.Find("PlayerHPBar").GetComponent<PlayerHpBar>();
        playerHpBar.InitializedHpBar(spaceShip.getHp());

        // �e�̔��ˏ����̊J�n
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

        // ���@�̈ړ��������������s
        RestrictPlayerMovement();
    }

    /// <summary>
    /// ���@�̈ړ���������
    /// </summary>
    void RestrictPlayerMovement()
    {
        // ���@�̈ړ����W�ŏ��l���r���[�|�[�g����擾�i�ŏ��l��0,0�j
        Vector2 minCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.05f, 0.1f));
        // ���@�̈ړ����W�ő�l�����r���[�|�[�g����擾�i�ő�l��1,1�j
        Vector2 maxCoord = Camera.main.ViewportToWorldPoint(new Vector2(0.95f, 0.85f));

        // ���@�̍��W���擾���ăx�N�g�� position �Ɋi�[
        Vector2 position = transform.position;
        // position.x �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        position.x = Mathf.Clamp(position.x, minCoord.x, maxCoord.x);
        // position.y �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        position.y = Mathf.Clamp(position.y, minCoord.y, maxCoord.y);

        // ���@�̈ړ��͈͂� pos �̍ŏ��l�ƍő�l�͈̔͂ɐ�������
        transform.position = position;
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
            // �e�̍폜
            Destroy(collider.gameObject);
        }

        // ���C���[����EnemyBullet�܂���Enemy�̏ꍇ
        if (layerName == "EnemyBullet" || layerName == "Enemy")
        {
            // �_���[�W����
            spaceShip.damage();

            // HP�o�[�̕ύX����
            playerHpBar.SetPlayerHpBar(spaceShip.getHp());

            // HP��0�ɂȂ������̏���
            if (spaceShip.getHp() <= 0)
            {
                // ��������
                spaceShip.Explosion();

                // PlayerPrefs�ɍŏI�X�R�A���i�[
                GameObject canvasObject = GameObject.Find("Canvas").gameObject;
                GameObject textObject = canvasObject.transform.Find("ScoreNumber").gameObject;
                string thisScore = textObject.GetComponent<ScoreNumber>().GetScoreNumber();

                PlayerPrefs.SetString("thisScore", thisScore);

                // �v���C���[���폜
                Destroy(gameObject);

                // ���U���g��ʂɑJ��
                SceneManager.LoadScene("Result");
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
            // �����̍��W����Shot���\�b�h�̈����ɓn��
            spaceShip.Shot(transform);
            // shotDelay�b�҂�
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
