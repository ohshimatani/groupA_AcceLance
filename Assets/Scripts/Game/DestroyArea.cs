using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    /// <summary>
    /// レイヤー名がDestroyArea以外のオブジェクトはDestroyする
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);
        if ("DestroyArea".Equals(layerName))
        {
            return;
        }

        // UpperDestoryAreaでDestoryするのはPlayerBulletのみとする
        if ("UpperDestroyArea".Equals(gameObject.name))
        {
            if ("PlayerBullet".Equals(layerName))
            {
                Destroy(other.gameObject);
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
