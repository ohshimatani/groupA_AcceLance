using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanjiCellManager : MonoBehaviour
{
    public void onClick()
    {
        // pushedKanjiManager��GetComponent
        PushedKanjiManager pushedKanjiManager = GameObject.Find("PushedKanjiManager").GetComponent<PushedKanjiManager>();
        pushedKanjiManager.Sample();
    }
}
