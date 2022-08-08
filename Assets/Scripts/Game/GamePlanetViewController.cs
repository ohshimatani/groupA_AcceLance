using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlanetViewController : MonoBehaviour
{
    // 生成するPlanetオブジェクトのプレハブ
    [SerializeField] GameObject nextPlanetPrefab;

    // Instantiateで画面枠上に惑星を生成する座標
    private Vector3 topPosition = new Vector3(5.5f, 11.5f, 0.0f);

    // 画面内に惑星を配置する座標
    private const float setPositionY = 1.5f;

    // 画面枠下に惑星を移動させる座標
    private const float underPositionY = -8.5f;

    // アニメーションの時間（秒）
    private const float DURATION = 2f;

    /// <summary>
    /// 現在ゲーム画面上に表示されているPlanetイメージに惑星の画像をセットする
    /// </summary>
    /// <param name="planet"></param>
    public void InitCurrentPlanetImage(Planet planet)
    {
        SpriteRenderer planetSprite = GameObject.Find("CurrentPlanet").GetComponent<SpriteRenderer>();
        planetSprite.sprite = planet.sprite;
    }

    /// <summary>
    /// ゲーム画面内の惑星を次の惑星に変更する
    /// </summary>
    /// <param name="planet"></param>
    public void ChangeNextPlanet(Planet planet)
    {
        // ① nextPlanetをInstantiate、および、画像のセット
        SpriteRenderer nextPlanetSprite = nextPlanetPrefab.GetComponent<SpriteRenderer>();
        nextPlanetSprite.sprite = planet.sprite;

        GameObject nextPlanet = Instantiate(nextPlanetPrefab, topPosition, transform.rotation);

        // ② currentPlanetとnextPlanetにアニメーション処理を実行
        GameObject currentPlanet = GameObject.Find("CurrentPlanet");
        DropOutAnimator(currentPlanet);
        DropInAnimator(nextPlanet);

        // ③ nextPlanetのオブジェクト名をcurrentPlanetに変更する
        nextPlanet.name = "CurrentPlanet";
    }
    
    /// <summary>
    /// 惑星が切り替わった際に流すサウンド
    /// </summary>
    public void PlaySoundEffect()
    {
        AudioClip audioClip = gameObject.GetComponent<AudioSource>().clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    /// <summary>
    /// ドロップインするときのアニメーション。ドロップインした後にDestory
    /// </summary>
    /// <param name="nextObj"></param>
    private void DropInAnimator(GameObject nextObj)
    {
        nextObj.transform.DOMoveY(setPositionY, DURATION);
    }

    /// <summary>
    /// ドロップアウトするときのアニメーション
    /// </summary>
    /// <param name="currentObj"></param>
    private void DropOutAnimator(GameObject currentObj)
    {
        currentObj.transform.DOMoveY(underPositionY, DURATION);
        Destroy(currentObj, DURATION);
    }
}
