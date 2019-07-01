using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // 스크린 해상도 고정
        Screen.SetResolution(800, 480, false);
    }

    private void GameOver()
    {
        // 결과창 띄우기
    }

}
