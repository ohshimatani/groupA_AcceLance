using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GradeType
{
    ALL,
    FIRST = 1,
    SECOND = 2
}

public class StageSelectManager : MonoBehaviour
{
    public static GradeType gradeType { get; set; }
}
