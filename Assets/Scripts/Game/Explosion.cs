using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{   
    /// <summary>
    /// アニメーションの終了処理
    /// </summary>
    void OnAnimationFinish()
    {
        // オブジェクトの削除
        Destroy(gameObject);
    }
}
