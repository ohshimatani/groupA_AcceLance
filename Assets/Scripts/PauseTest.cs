using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTest : MonoBehaviour
{
    private bool isStop = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStop)
            {
                Time.timeScale = 1f;
                isStop = false;
            }
            else
            {
                Time.timeScale = 0;
                isStop = true;
            }
        }
    }
}
