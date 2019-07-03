﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public Text coinNum;
    private int coin;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // 스크린 해상도 고정
        Screen.SetResolution(800, 480, false);
    }

    public void GetCoin(int coinScore)
    {
        coin += coinScore;
        coinNum.text = coin.ToString();
    }

    private void GameOver()
    {
        // 결과창 띄우기
    }

}
