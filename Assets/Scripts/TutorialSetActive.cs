using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    
    public GameObject gameObject;


    public void ClickedButton()
    {
        if (gameObject.activeSelf)
        {
            //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�
            gameObject.SetActive(false);
        }
        else {
            //�{�^���������ꂽ��I�u�W�F�N�g���\�������
            gameObject.SetActive(true); 
        }
       
        
    }
    


    
}
