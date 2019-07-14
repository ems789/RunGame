using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public int sceneNum;
    public bool hasCheckCondition = true; // 체크 해야할 조건을 가지고 있는지

    public void NextScene()
    {
        if (hasCheckCondition) // 체크 해야할 조건이 있으면
        {
            if(GetComponent<ConditionCheck>().TextCheck())
                SceneManager.LoadScene(sceneNum);
        }
        else
            SceneManager.LoadScene(sceneNum);
    }
}
