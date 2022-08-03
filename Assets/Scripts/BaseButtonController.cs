using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButtonController : MonoBehaviour
{
    public BaseButtonController baseButtonController;

    public void OnClick()
    {
        if (baseButtonController == null)
        {
            throw new System.Exception("Button instance is null");
        }

        baseButtonController.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName) { }
}
