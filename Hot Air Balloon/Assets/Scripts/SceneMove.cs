using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public int sceneNum;

    public void NextScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
