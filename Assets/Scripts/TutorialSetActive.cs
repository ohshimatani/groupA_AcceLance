using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    
    public GameObject HowToOperaion1;//XD�̃`���[�g���A��1-1-1�̗v�f
    public GameObject HowToOpetaion2;//XD�̃`���[�g���A��1-1-2�̗v�f

    void Start()
    {
        HowToOpetaion2.SetActive(false);
    }

    public void ClickedButton()
    {
        //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�
        HowToOperaion1.SetActive(false);

        //�{�^���������ꂽ��I�u�W�F�N�g���\�������
        HowToOpetaion2.SetActive(true); 
    }
    


    
}
