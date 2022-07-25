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
            //ボタンが押されたらオブジェクトが非表示になる
            gameObject.SetActive(false);
        }
        else {
            //ボタンが押されたらオブジェクトが表示される
            gameObject.SetActive(true); 
        }
       
        
    }
    


    
}
