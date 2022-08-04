using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewController : MonoBehaviour
{
    // ˜g“à‚ÌImage
    [SerializeField] Image planetImage;

    // uZZ ‚Ü‚Å ‚Æ‚¤‚½‚ÂIv‚ÌText
    [SerializeField] Text planetNameText;

    /// <summary>
    /// Image‚ÆText‚ğ”½‰f‚³‚¹‚é
    /// </summary>
    /// <param name="planet"></param>
    public void SetViewPropertyByPlanet(Planet planet)
    {
        // Text‚É”½‰f
        planetNameText.text = planet.nameJ + " ‚Ü‚Å ‚Æ‚¤‚½‚ÂI";

        // ‰æ‘œ‚ğ”½‰f
        planetImage.sprite = planet.sprite;

    }
}
