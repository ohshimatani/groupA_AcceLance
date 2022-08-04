using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    /// <summary>
    /// トリガーから出た時の処理
    /// 衝突した相手の Collider2D コンポーネントを引数 c に格納
    /// </summary>
    /// <param name="c"></param>
    void OnTriggerExit2D(Collider2D c)
    {
        // 引数 c に格納されたコンポーネント（オブジェクト）を削除
        Destroy(c.gameObject);
    }
}
