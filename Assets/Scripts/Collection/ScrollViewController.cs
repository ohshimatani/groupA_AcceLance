using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    // Content���A�^�b�`
    [SerializeField] RectTransform contentRectTransform;

    // KanjiCell��Prefab��ݒ�
    [SerializeField] GameObject buttonCell;

    /// <summary>
    /// �y���u���z80��KanjiCell�𐶐����A�z�u
    /// Cell�̒��g�iText�j��1~80�̐���
    /// </summary>
    private void Start()
    {
        for (int i = 1; i <= 80; i++)
        {
            GameObject kanjiCell = Instantiate(buttonCell, contentRectTransform);
            kanjiCell.GetComponentInChildren<Text>().text = i.ToString();
        }
    }
}
