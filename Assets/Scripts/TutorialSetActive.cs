using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{

    [SerializeField] GameObject howToOperation1;//XD�̃`���[�g���A��1-1-1�̗v�f
    [SerializeField] GameObject howToOperation2;//XD�̃`���[�g���A��1-1-2�̗v�f

    void Start()
    {
        howToOperation2.SetActive(false);
    }

    public void ClickedButton()
    {
        //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�
        howToOperation1.SetActive(false);

        //�{�^���������ꂽ��I�u�W�F�N�g���\�������
        howToOperation2.SetActive(true); 
    }
    


    
}
