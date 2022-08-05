using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirection : MonoBehaviour
{

    public enum DIRECTION_TYPE: int
    {
        Straight = 0
        , LowerLeft = 1
        , LowerRight = 2
    }

    /// <summary>
    /// �܂��������̕���
    /// </summary>
    /// <returns></returns>
    public Vector2 StraightDirection()
    {
        return new Vector2(0, -1f);
    }

    /// <summary>
    /// �΂ߍ����̕���
    /// </summary>
    /// <returns></returns>
    public Vector2 LowerLeftDirection()
    {
        return new Vector2(-0.7f, -1f);
    }

    /// <summary>
    /// �΂߉E���̕���
    /// </summary>
    /// <returns></returns>
    public Vector2 LowerRightDirection()
    {
        return new Vector2(0.7f, -1f);
    }
}
