using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public int maxHP = 100;
    public int currentHP;

    public int life = 1;

    public bool isDead = false;

    // 레벨
    // 현재 경험치, 필요 경험치

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        currentHP = maxHP;

        // 체력이 지속적으로 감소
        StartCoroutine("HPDown");
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            isDead = true;            
        }

        life = GameManager.instance.LifeCheck(life);
        // 게임 매니저에서 생명이 남아있는지 체크, 생명이 남아있으면 부활, 2초 무적
        // 생명이 남아있지 않으면 게임오버
    }

    IEnumerator HPDown()
    {
        while (currentHP >= 0)
        {
            currentHP -= 20;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
