using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretCellButtonController : MonoBehaviour
{
    /// <summary>
    /// クリックされたときに発動するメソッド。
    /// 左画面にハテナを反映させる。
    /// </summary>
    public void OnClickShowDisplay()
    {
        // 左のコンテナにアタッチされているKanjiDisplayをgetし、値を反映させる関数を呼ぶ
        GameObject.Find("LeftContainer").GetComponent<KanjiDisplay>().DisplayHatena();
    }
}
