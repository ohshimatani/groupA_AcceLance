using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAreaManager : MonoBehaviour
{

    // トリガーから出た時の処理
    // 衝突した相手の Collider2D コンポーネントを引数 c に格納
    void OnTriggerExit2D(Collider2D c)
    {
        // 引数 c に格納されたコンポーネント（オブジェクト）を削除
        Destroy(c.gameObject);
    }
}
