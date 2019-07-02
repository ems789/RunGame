﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public Text lifeText;

    public int maxHP = 100;
    public int currentHP;
    public int life = 1;
    public int level = 1;

    public bool isDead = false;

    private SpriteRenderer playerSprite;

    // 레벨
    // 현재 경험치, 필요 경험치

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        playerSprite = GetComponent<SpriteRenderer>();

        currentHP = maxHP;

        // 체력이 지속적으로 감소
        StartCoroutine("HPDown");
    }

    public void Resurrection()
    {
        if (life > 0 && isDead)
        {
            // 부활 이펙트 추가 필요
            life--;
            lifeText.text = "x " + life.ToString();

            StartCoroutine("AlphaBlink");

            isDead = false;
            currentHP = maxHP;
            StartCoroutine("HPDown");
        }
        else
            return;
    }

    // 에어를 먹었을 때 체력 회복
    public void HPUp(int recovery)
    {
        Debug.Log("회복량: " + recovery);
        currentHP += recovery;
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    IEnumerator HPDown()
    {
        while (currentHP >= 0)
        {
            currentHP -= 2;
            if (currentHP <= 0)
                isDead = true;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 알파값 깜빡임 처리
    // 깜빡이는 동안 무적 처리 필요
    IEnumerator AlphaBlink()
    {
        int coolTime = 0;

        while(coolTime < 11)
        {
            if (coolTime == 0)
                playerSprite.color = new Color32(255, 255, 255, 255);
            else if (coolTime % 2 == 0)
                playerSprite.color = new Color32(255, 255, 255, 90);
            else
                playerSprite.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);
            coolTime++;
        }

        playerSprite.color = new Color32(255, 255, 255, 255);
    }
}
