using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetImageManager : MonoBehaviour {

    // ResourcesファイルのPlanetイメージを配列で取得
    Sprite planetImages = Resources.Load<Sprite>("Resouces/Planets/Earth");

    void Start() {
        Debug.Log(planetImages.name);
    }

}
