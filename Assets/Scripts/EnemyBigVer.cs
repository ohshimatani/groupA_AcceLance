using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyBigVer : MonoBehaviour
{
    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    private SpaceShip spaceShip;

    // �X�N���v�gScoreNumber�̃R���|�[�l���g���i�[����ϐ�
    private ScoreNumber scoreNumber;

    public KanjiInfo kanjiInfo;

    // �X�N���v�gPlayerHpBar�̃R���|�[�l���g���i�[����ϐ�
    PlayerHpBar enemyHpBar;

    /// <summary>
    /// �Q�[���X�^�[�g���̏���
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        scoreNumber = GameObject.Find("ScoreNumber").GetComponent<ScoreNumber>();

        // HP�o�[�̏����ݒ�
        // TODO; ���˂݁[HPBar����ō��
        GameObject canvasObject = gameObject.transform.Find("Canvas").gameObject;
        enemyHpBar = canvasObject.transform.Find("EnemyHPBar").GetComponent<PlayerHpBar>();
        enemyHpBar.InitializedHpBar(spaceShip.getHp());


        //-----���̈ړ������𑽗l������

        // <<< Enemy.cs
        //
        // ��ʏォ�牺�Ɉړ�������
        //spaceShip.Move(transform.up * -1);
        //
        //-----
        // >>> EnemyBigVer.cs
        EnemyDirection enemyDirection = new EnemyDirection();

        // 0�`2�i�����̎�ށj�̗����𐶐�
        System.Random randomGenerator = new System.Random();
        int directionTypeNumber = 2;
        int randomNumber = randomGenerator.Next(0, directionTypeNumber);

        // �����_���ɉF���D�̐i�s����������
        Vector2 direction;
        switch(randomNumber)
        {
            case 0:
                // �^���ֈړ�
                direction = enemyDirection.StraightDirection();
                break;
            case 1:
                // �����ֈړ�
                direction = enemyDirection.LowerLeftDirection();
                break;
            case 2:
                // �E���ֈړ�
                direction = enemyDirection.LowerRightDirection();
                break;
            default:
                // �f�t�H���g�͐^���ֈړ�
                direction = enemyDirection.StraightDirection();
                break;
        }
        spaceShip.Move(direction);



        //-----�ړ������̑��l�������A�����܂�



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
                scoreNumber.IncrementScoreNumber();

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
