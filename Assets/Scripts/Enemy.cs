using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // �X�N���v�gSpaceShip�̃R���|�[�l���g���i�[����ϐ�
    private SpaceShip spaceShip;

    // �X�N���v�gScoreNumber�̃R���|�[�l���g���i�[����ϐ�
    private ScoreNumber scoreNumber;

    public KanjiInfo kanjiInfo;

    /// <summary>
    /// �Q�[���X�^�[�g���̏���
    /// </summary>
    void Start()
    {
        spaceShip = GetComponent<SpaceShip>();
        scoreNumber = GameObject.Find("ScoreNumber").GetComponent<ScoreNumber>();

        // ��ʏォ�牺�Ɉړ�������
        spaceShip.Move(transform.up * -1);

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
