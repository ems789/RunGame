using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public int sceneNum;

    public void NextScene()
    {
        if(GetComponent<ConditionCheck>().TextCheck()) // 씬 이동 전에 조건을 만족하는지 검사
            SceneManager.LoadScene(sceneNum);
    }
}
