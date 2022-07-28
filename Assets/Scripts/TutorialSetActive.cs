using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    //��ʂ��Ƃɕ\��������Q�[���I�u�W�F�N�g���i�[����z��̐錾
    public GameObject[] tutorialObjectArray;

    //���֐i�ށA�߂邽�߂̖��{�^���̐錾
    [SerializeField] GameObject goStepButton;
    [SerializeField] GameObject goBackButton;

    //�z��ԍ��ƘA�������邽�߂̕ϐ�
    private static int num = 0;

    //�z��ԍ��̍ő�l�ƍŏ��l
    private int minNum = 0;
    private int maxNum = 4;


    void Start()
    {
        //�ŏ��ɕ\�����������I�u�W�F�N�g�̂ݕ\���A���̑����\���ɂ���
        foreach (GameObject gameObject in tutorialObjectArray)
        {
            gameObject.SetActive(false);
        }
        tutorialObjectArray[0].SetActive(true);

        //�i�ރ{�^����\���A�߂�{�^�����\���ɂ���
        goStepButton.SetActive(true);
        goBackButton.SetActive(false);
    }

    //�i�ރ{�^�������������̏���
    public void OnClickNextButton()
    {
        //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�
        tutorialObjectArray[num].SetActive(false);
        
        if(num == minNum)
        {
            goBackButton.SetActive(true);
        }

        //�z��ԍ������Z����
        num += 1;

        //�{�^���������ꂽ��I�u�W�F�N�g���\�������
        tutorialObjectArray[num].SetActive(true); 

        //�z��ԍ����ő�̎��i�ŏI�y�[�W��\�����Ă��鎞�j�A�i�ރ{�^�����\���ɂ���
        if(num == maxNum)
        {
            goStepButton.SetActive(false);
        }
    }

    //�߂�{�^�����������Ƃ��̏���
    public void OnClickBackButton()
    {
        //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�
        tutorialObjectArray[num].SetActive(false);

        //�z��ԍ����ő�l�ȊO�̎��i�ŏI�y�[�W�ȊO��\�����Ă��鎞�j�A�i�ރ{�^����\������
        if (num != maxNum)
        {
            goStepButton.SetActive(true);
        }

        //�z��ԍ������Z����
        num -= 1;

        //�{�^���������ꂽ��I�u�W�F�N�g���\�������
        tutorialObjectArray[num].SetActive(true);

        //�z��ԍ����ŏ��̎��i�ŏ��̃y�[�W��\�����Ă���Ƃ��j�A�߂�{�^�����\���ɂ���
        if (num == minNum)
        {
            goBackButton.SetActive(false);
        }

    }
    


    
}
