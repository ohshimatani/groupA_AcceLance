using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour
{
    // �g����Image
    [SerializeField] Image planetImage;

    // �u�Z�Z �܂� �Ƃ����I�v��Text
    [SerializeField] Text planetNameText;

    /// <summary>
    /// Image��Text�𔽉f������
    /// </summary>
    /// <param name="planet"></param>
    public void SetViewPropertyByPlanet(Planet planet)
    {
        // Text�ɔ��f
        planetNameText.text = planet.nameJ + " �܂� �Ƃ����I";

        // �摜�𔽉f
        planetImage.sprite = planet.sprite;

    }
}
