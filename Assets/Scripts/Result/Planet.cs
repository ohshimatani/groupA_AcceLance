using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    // �f���̖��O�i���{��j
    private string nameJ;

    // �f���̖��O�i�p��j
    private string nameE;

    // �X�R�A��Max�l��Min�l
    private int scoreMax;
    private int scoreMin;

    /// <summary>
    /// nameJ�̃A�N�Z�b�T
    /// </summary>
    public string NameJ {
        get {
            return nameJ;
        }
        set {
            nameJ = value;
        }
    }

    /// <summary>
    /// nameE�̃A�N�Z�b�T
    /// </summary>
    public string NameE {
        get {
            return nameE;
        }
        set {
            nameE = value;
        }
    }

    /// <summary>
    /// scoreMax�̃A�N�Z�b�T
    /// </summary>
    public int ScoreMax {
        get {
            return scoreMax;
        }
        set {
            scoreMax = value;
        }
    }

    /// <summary>
    /// scoreMin�̃A�N�Z�b�T
    /// </summary>
    public int ScoreMin {
        get {
            return scoreMin;
        }
        set {
            scoreMin = value;
        }
    }


}
