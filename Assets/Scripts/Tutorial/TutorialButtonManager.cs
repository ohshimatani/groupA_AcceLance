using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButtonManager: MonoBehaviour
{
    // �y�[�W���Ƃɕ\��������Q�[���I�u�W�F�N�g���i�[����z��̐錾
    [SerializeField] GameObject[] pageObjects;

    // ���֐i�ށA�߂邽�߂̖��{�^���̐錾
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject prevButton;

    // �z��ԍ��ƃy�[�W��A�������邽�߂̕ϐ�
    private static int pageNum;

    // �y�[�W���̍ő�l�ƍŏ��l
    private const int MIN_PAGE_NUM = 0;
    private const int MAX_PAGE_NUM = 6;


    void Start()
    {
        pageNum = 0;

        // �ŏ��ɕ\�����������I�u�W�F�N�g�̂ݕ\���A���̑����\���ɂ���
        foreach (GameObject gameObject in pageObjects)
        {
            gameObject.SetActive(false);
        }
        pageObjects[MIN_PAGE_NUM].SetActive(true);

        // �i�ރ{�^����\���A�߂�{�^�����\���ɂ���
        nextButton.SetActive(true);
        prevButton.SetActive(false);
    }

    /// <summary>
    /// �i�ރ{�^���A�߂�{�^���ɂ��āA�\���E��\���𐧌䂷�郁�\�b�h
    /// </summary>
    private void SetButtonActive()
    {
        // �ŏ��̃y�[�W��\���������͖߂�{�^�����\���ɂ���
        if (pageNum == MIN_PAGE_NUM)
        {
            prevButton.SetActive(false);
        }
        // �Ō�̃y�[�W��\���������͐i�ރ{�^�����\���ɂ���
        else if (pageNum == MAX_PAGE_NUM)
        {
            nextButton.SetActive(false);
        }
        // �Ō�̃y�[�W�ƍŌ�̃y�[�W�ȊO�̎��́A�i�ރ{�^���Ɩ߂�{�^����\������
        else
        {
            prevButton.SetActive(true);
            nextButton.SetActive(true);
        }
    }

    /// <summary>
    /// �y�[�W�ԍ���ύX���A�y�[�W���Ƃ̃I�u�W�F�N�g�̕\���E��\����؂�ւ��郁�\�b�h
    /// </summary>
    /// <param name="buttonType"></param>
    private void SetPageObject(string buttonType)
    {
        // ���ɕ\������Ă����I�u�W�F�N�g���\���ɂ���
        pageObjects[pageNum].SetActive(false);

        // �y�[�W��߂������Ƀy�[�W�ԍ��� -1 ����
        if ("prev".Equals(buttonType))
        {
            pageNum--;
        }

        // �y�[�W��i�߂����Ƀy�[�W�ԍ���+1 ����
        if ("next".Equals(buttonType))
        {
            pageNum++;
        }

        // ���ɕ\���������I�u�W�F�N�g���\�������
        pageObjects[pageNum].SetActive(true);
    }



    /// <summary>
    /// �i�ރ{�^�������������̏���
    /// </summary>
    public void OnClickNextButton()
    {
        SetPageObject("next");
        SetButtonActive();
    }

    /// <summary>
    /// �߂�{�^�����������Ƃ��̏���
    /// </summary>
    public void OnClickPrevButton()
    {
        SetPageObject("prev");
        SetButtonActive();
    }

}
