using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {
    // �f���̖��O�i�p��j
    private string nameE;

    // �f���̖��O�i���{��j
    private string nameJ;

    // �X�R�A��Max�l��Min�l
    private int scoreMin;

    // �v���l�b�g�̉摜�i�X�v���C�g�j
    private Sprite sprite;

    private float position;

    public Planet(string nameE, string nameJ, int scoreMin, float position)
    {
        this.nameE = nameE;
        this.nameJ = nameJ;
        this.scoreMin = scoreMin;
        this.sprite = Resources.Load<Sprite>("Planets/" + NameE);
        this.position = position;
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

    /// <summary>
    /// planetSprite�̃A�N�Z�b�T
    /// </summary>
    public Sprite Sprite {
        get {
            return sprite;
        }
        set {
            sprite = value;
        }
    }


}
