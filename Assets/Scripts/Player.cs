using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
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
        Clamp();
    }

    /// <summary>
    /// ���@�̈ړ���������
    /// </summary>
    void Clamp()
    {
        //���@�̈ړ��ŏ����W�i�x�N�g���j���`�i��肤��ŏ��̒l��0,0�j
        Vector2 MINVECTOR = new Vector2(0.05f, 0.1f);
        //���@�̈ړ��ő���W�i�x�N�g���j���`�i��肤��ő�̒l��1,1�j
        Vector2 MAXVECTOR = new Vector2(0.95f, 0.85f);
        
        // ���@�̈ړ����W�ŏ��l���r���[�|�[�g����擾
        Vector2 min = Camera.main.ViewportToWorldPoint(MINVECTOR);
        // ���@�̈ړ����W�ő�l�����r���[�|�[�g����擾
        Vector2 max = Camera.main.ViewportToWorldPoint(MAXVECTOR);

        // ���@�̍��W���擾���ăx�N�g�� pos �Ɋi�[
        Vector2 pos = transform.position;
        // pos.x �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        // pos.y �̒l���ŏ��l min �ő�l max �͈̔͂ɐ�������
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // ���@�̈ړ��͈͂� pos �̍ŏ��l�ƍő�l�͈̔͂ɐ�������
        transform.position = pos;
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
