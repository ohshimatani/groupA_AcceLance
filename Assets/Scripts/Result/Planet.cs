using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {
    // �f���̖��O�i���{��j
    private string nameJ;

    // �f���̖��O�i�p��j
    private string nameE;

    // �X�R�A��Max�l��Min�l
    private int scoreMin;

    public Planet(string nameJ, string nameE, int scoreMin) {
        this.nameJ = nameJ;
        this.nameE = nameE;
        this.scoreMin = scoreMin;
    }

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
