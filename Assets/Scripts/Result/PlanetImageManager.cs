using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetImageManager : MonoBehaviour {

    // Resources�t�@�C����Planet�C���[�W��z��Ŏ擾
    Sprite planetImages = Resources.Load<Sprite>("Resouces/Planets/Earth");

    void Start() {
        Debug.Log(planetImages.name);
    }

}
