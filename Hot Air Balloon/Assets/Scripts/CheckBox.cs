using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour
{
    private bool isCheck = false;
    public Image checkImage;


    public void OnClick()
    {
        Debug.Log("들어옴" + !isCheck);
        isCheck = !isCheck;
        if (isCheck)
            checkImage.enabled = true;
        else
            checkImage.enabled = false;
    }
}
