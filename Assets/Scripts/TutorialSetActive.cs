using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSetActive: MonoBehaviour
{

    [SerializeField] GameObject howToOperation1;//XDのチュートリアル1-1-1の要素
    [SerializeField] GameObject howToOperation2;//XDのチュートリアル1-1-2の要素

    void Start()
    {
        howToOperation2.SetActive(false);
    }

    public void ClickedButton()
    {
        //ボタンが押されたらオブジェクトが非表示になる
        howToOperation1.SetActive(false);

        //ボタンが押されたらオブジェクトが表示される
        howToOperation2.SetActive(true); 
    }
    


    
}
