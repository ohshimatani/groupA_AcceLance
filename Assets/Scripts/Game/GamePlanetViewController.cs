using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GamePlanetViewController : MonoBehaviour
{
    // ��������Planet�I�u�W�F�N�g�̃v���n�u
    [SerializeField] GameObject nextPlanetPrefab;

    // Instantiate�ŉ�ʘg��ɘf���𐶐�������W
    private Vector3 topPosition = new Vector3(5.5f, 11.5f, 0.0f);

    // ��ʓ��ɘf����z�u������W
    private const float setPositionY = 1.5f;

    // ��ʘg���ɘf�����ړ���������W
    private const float underPositionY = -8.5f;

    // �A�j���[�V�����̎��ԁi�b�j
    private const float DURATION = 2f;

    /// <summary>
    /// ���݃Q�[����ʏ�ɕ\������Ă���Planet�C���[�W�ɘf���̉摜���Z�b�g����
    /// </summary>
    /// <param name="planet"></param>
    public void InitCurrentPlanetImage(Planet planet)
    {
        SpriteRenderer planetSprite = GameObject.Find("CurrentPlanet").GetComponent<SpriteRenderer>();
        planetSprite.sprite = planet.sprite;
    }

    /// <summary>
    /// �Q�[����ʓ��̘f�������̘f���ɕύX����
    /// </summary>
    /// <param name="planet"></param>
    public void ChangeNextPlanet(Planet planet)
    {
        // �@ nextPlanet��Instantiate�A����сA�摜�̃Z�b�g
        SpriteRenderer nextPlanetSprite = nextPlanetPrefab.GetComponent<SpriteRenderer>();
        nextPlanetSprite.sprite = planet.sprite;

        GameObject nextPlanet = Instantiate(nextPlanetPrefab, topPosition, transform.rotation);

        // �A currentPlanet��nextPlanet�ɃA�j���[�V�������������s
        GameObject currentPlanet = GameObject.Find("CurrentPlanet");
        DropOutAnimator(currentPlanet);
        DropInAnimator(nextPlanet);

        // �B nextPlanet�̃I�u�W�F�N�g����currentPlanet�ɕύX����
        nextPlanet.name = "CurrentPlanet";
    }
    
    /// <summary>
    /// �f�����؂�ւ�����ۂɗ����T�E���h
    /// </summary>
    public void PlaySoundEffect()
    {
        AudioClip audioClip = gameObject.GetComponent<AudioSource>().clip;
        gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    /// <summary>
    /// �h���b�v�C������Ƃ��̃A�j���[�V�����B�h���b�v�C���������Destory
    /// </summary>
    /// <param name="nextObj"></param>
    private void DropInAnimator(GameObject nextObj)
    {
        nextObj.transform.DOMoveY(setPositionY, DURATION);
    }

    /// <summary>
    /// �h���b�v�A�E�g����Ƃ��̃A�j���[�V����
    /// </summary>
    /// <param name="currentObj"></param>
    private void DropOutAnimator(GameObject currentObj)
    {
        currentObj.transform.DOMoveY(underPositionY, DURATION);
        Destroy(currentObj, DURATION);
    }
}
