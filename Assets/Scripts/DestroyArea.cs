using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    /// <summary>
    /// �g���K�[����o�����̏���
    /// �Փ˂�������� Collider2D �R���|�[�l���g������ c �Ɋi�[
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerExit2D(Collider2D c)
    {
        // ���� c �Ɋi�[���ꂽ�R���|�[�l���g�i�I�u�W�F�N�g�j���폜
        Destroy(c.gameObject);
    }
}
