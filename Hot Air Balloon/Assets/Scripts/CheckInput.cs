using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 텍스트에 입력한 문자열이 올바른지 체크를 하는 클래스
public class CheckInput : MonoBehaviour
{
    public Text text;

    public void Check()
    {
        // 텍스트 검사하는 작업, 경고 UI를 띄우는 작업 필요
        // 이름을 저장하는 작업 필요
        GetComponent<SceneMove>().NextScene();
    }
}
