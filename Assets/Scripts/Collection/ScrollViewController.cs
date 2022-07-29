using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    [SerializeField] private RectTransform contentRectTransform;
    [SerializeField] private Button buttonCell;

    private void Start()
    {
        for (int i = 1; i <= 80; i++)
        {
            var obj = Instantiate(buttonCell, contentRectTransform);
            obj.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
