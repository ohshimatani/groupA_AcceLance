using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject gameObject;

    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedButton()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else { 
            gameObject.SetActive(true); 
        }
       
        
    }
    //�{�^���������ꂽ��I�u�W�F�N�g����\���ɂȂ�


    //�{�^���������ꂽ��I�u�W�F�N�g���\�������
}
