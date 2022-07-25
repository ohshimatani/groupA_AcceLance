using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{
    
    public GameObject HowToOperaion1;//XDのチュートリアル1-1-1の要素
    public GameObject HowToOpetaion2;//XDのチュートリアル1-1-2の要素

    void Start()
    {
        HowToOpetaion2.SetActive(false);
    }

    public void ClickedButton()
    {
        //ボタンが押されたらオブジェクトが非表示になる
        HowToOperaion1.SetActive(false);

        //ボタンが押されたらオブジェクトが表示される
        HowToOpetaion2.SetActive(true); 
    }
    


    
}
