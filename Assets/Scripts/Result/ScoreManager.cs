using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    private Planet[] planets;

    /// <summary>
    /// ���z�n�̏��ԂŘf���̗v�f�����z����쐬
    /// </summary>
    /// <returns>���z�n�̏��ԂŘf���̗v�f�����z��</returns>
    private void Start() {
        planets = new Planet[] {
            new Planet("Mercury", "����", 0)
            , new Planet("Venus", "����", 4)
            , new Planet("Earth", "�n��", 8)
            , new Planet("Mars", "�ΐ�", 11)
            , new Planet("Jupiter", "�ؐ�", 16)
            , new Planet("Saturn", "�y��", 21)
            , new Planet("Uranus", "�V����", 31)
            , new Planet("Neptune", "�C����", 51)
        };

    }

    /// <summary>
    /// �X�R�A�ɉ������f���N���X��Ԃ��֐�
    /// TODO:Game�V�[�����烉���N���󂯎������ɕύX����\������
    /// </summary>
    /// <param name="thisScore">����̃X�R�A</param>
    /// <returns>�X�R�A�ɉ������f���N���X</returns>
    public Planet JudgeRank(int thisScore) {
        
        Planet planet = planets.First();

        for (int i = planets.Length - 1; i >= 0; i--) {
            planet = planets[i];
            if (thisScore >= planet.ScoreMin) {
                break;
            }
        }

        return planet;
    }

    


}
