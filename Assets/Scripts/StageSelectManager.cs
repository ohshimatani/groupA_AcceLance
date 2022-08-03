using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StageMode
{
    ALL,
    GAKUNEN_1 = 1,
    GAKUNEN_2 = 2
}

public class StageSelectManager : MonoBehaviour
{
    public static StageMode stageMode { get; set; }
}
