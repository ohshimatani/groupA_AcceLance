using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{
    // �f���̖��O�i�p��j
    public string nameE { get; set; }

    // �f���̖��O�i���{��j
    public string nameJ { get; set; }

    // �X�R�A��Min�l
    public int scoreMin { get; set; }

    // �v���l�b�g�̉摜�i�X�v���C�g�j
    public Sprite sprite { get; set; }

    // �v���C���[�̈ʒu��X���W(horizontal)
    public float positionX { get; set; }

    public Planet(string nameE, string nameJ, int scoreMin, float positionX)
    {
        this.nameE = nameE;
        this.nameJ = nameJ;
        this.scoreMin = scoreMin;
        this.sprite = Resources.Load<Sprite>("Planets/" + nameE);
        this.positionX = positionX;
    }

}
