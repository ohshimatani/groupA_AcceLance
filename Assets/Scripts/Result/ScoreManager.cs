using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    /// <summary>
    /// ���z�n�̏��ԂŘf���̗v�f�����z����쐬
    /// </summary>
    /// <returns>���z�n�̏��ԂŘf���̗v�f�����z��</returns>
    private Planet[] createPlanetArray() {
        // �e�f���N���X�̖��O
        string[] planetNamesE = { "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune" };

        // �e�f���N���X�̖��O�i���{�ꖼ�j
        string[] planetNamesJ = { "����", "����", "�n��", "�ΐ�", "�ؐ�", "�y��", "�V����", "�C����" };

        // �e�f���N���X��臒l�ii�Ԗڂ̗v�f�������Ni�̍ő�l�j
        // TODO:�����͉��u���B���k�̏㌈�肷��
        // �C�����i�ō������N�j��ScoreMax�͕֋X��9999�Ƃ������A����ł����̂�...?
        int[] planetThresholds = { -1, 3, 7, 10, 15, 20, 30, 50, 9999 };

        // ���Ԃ�Planet�̗v�f��z��Ɋi�[
        Planet[] planetArray = new Planet[planetNamesE.Length];
        for (int i = 0; i < planetNamesE.Length; i++) {
            Planet planet = new Planet();
            planet.NameE = planetNamesE[i];
            planet.NameJ = planetNamesJ[i];
            planet.ScoreMin = planetThresholds[i] + 1;
            planet.ScoreMax = planetThresholds[i + 1];
            planetArray[i] = planet;
        }

        return planetArray;
    }

    public Planet judgeRank(int thisScore) {
        
        // �f���̔z��
        Planet[] planetArray = createPlanetArray();
        // �ō������N�i�C�����j
        Planet neptune = planetArray.Last();

        for (int i = 0; i < planetArray.Length; i++) {
            Planet planet = planetArray[i];
            // ����̃X�R�A���ǂ̘f���ɊY�����邩�����ԂɊm���߂�
            if (planet.ScoreMin <= thisScore && thisScore <= planet.ScoreMax) {
                return planet;
            }
        }

        return neptune;
    }

    


}
