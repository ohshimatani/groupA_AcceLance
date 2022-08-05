using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    public enum DIRECTION_TYPE
    {
        STRAIGHT
        , LOWER_LEFT
        , LOWER_RIGHT
    }

    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    private SpaceShip spaceShip;

    // �X�N���v�gGameManager�̃R���|�[�l���g���i�[����ϐ�
    private GameManager gameManager;

    public KanjiInfo kanjiInfo;

    // �X�N���v�gPlayerHpBar�̃R���|�[�l���g���i�[����ϐ�
    PlayerHpBar enemyHpBar;

    /// <summary>
    /// �Q�[���X�^�[�g���̏���
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // HP�o�[�̏����ݒ�
        // TODO; ���˂݁[HPBar����ō��
        GameObject canvasObject = gameObject.transform.Find("Canvas").gameObject;
        enemyHpBar = canvasObject.transform.Find("EnemyHPBar").GetComponent<PlayerHpBar>();
        enemyHpBar.InitializedHpBar(spaceShip.getHp());

        // ��ʏォ�牺�Ɉړ�������
        spaceShip.Move(transform.up * -1);

        // �����������_���Ɍ���
        System.Random random = new System.Random();

        // Enum�̍��ڐ����擾
        int directionTypeLength = Enum.GetNames(typeof(DIRECTION_TYPE)).Length;
        DIRECTION_TYPE directionType = (DIRECTION_TYPE)random.Next(directionTypeLength);

        Vector2 direction;
        switch (directionType)
        {
            case DIRECTION_TYPE.STRAIGHT:
                direction = new Vector2(0, -1f);
                break;
            case DIRECTION_TYPE.LOWER_LEFT:
                direction = new Vector2(-0.7f, -1f);
                break;
            case DIRECTION_TYPE.LOWER_RIGHT:
                direction = new Vector2(0.7f, -1f);
                break;
            default:
                throw new Exception("������Enum:DIRECTION_TYPE�ɊY�����܂���");
        }
        spaceShip.Move(direction);

        // �e�̔��ˏ��������s
        StartCoroutine("Shot");
    }

    public void SetKanjiText(KanjiInfo kanjiInfo)
    {
        this.kanjiInfo = kanjiInfo;
        GameObject canvasObject = gameObject.transform.Find("Canvas").gameObject;
        GameObject textObject = canvasObject.transform.Find("Text").gameObject;
        textObject.GetComponent<Text>().text = kanjiInfo.kanji;
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

            // HP�o�[�̕ύX����
            enemyHpBar.SetPlayerHpBar(spaceShip.getHp());

            // �e�̍폜
            Destroy(collider.gameObject);

            // HP��0�ɂȂ������̏���
            if (spaceShip.getHp() <= 0)
            {
                // ��������
                spaceShip.Explosion();

                // Score�̉��Z����
                gameManager.IncrementScore();

                // Json���̏㏑��
                // TODO: ���U���g��ʂւ̈ڍs�^�C�~���O�ł܂Ƃ߂čs�Ȃ��Ă��ǂ�
                JsonManager jsonManager = GameObject.Find("JsonManager").GetComponent<JsonManager>();
                jsonManager.UpdateDefeatCountByKanjiInfo(kanjiInfo);
                jsonManager.WriteJsonData();

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
                // �q�v�f�̃I�u�W�F�N�g�����擾
                string gameObjectName = transform.GetChild(i).gameObject.name;

                // ShotPosition�I�u�W�F�N�g�̂݁A�e�𐶐�����
                if (gameObjectName.Contains("ShotPosition"))
                {
                    // �q�v�f��S�Ď擾����
                    // TODO: �����̒e�𔭎˂����邩�ۂ��ɂ���ď�����ς���
                    Transform shotPosition = transform.GetChild(i);

                    // �e���v���C��[�Ɠ����ʒu/�p�x�Ő���
                    spaceShip.Shot(shotPosition);
                }
            }

            // shotDelay�b�҂�
            yield return new WaitForSeconds(spaceShip.shotDelay);
        }
    }
}
