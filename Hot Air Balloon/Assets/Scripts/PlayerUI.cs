using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;
    public Text level;

    private ColorBlock cb; // ColorBlock은 UI의 color를 관리

    public bool isCoroutineStarted = false; // 코루틴을 한번만 실행하기 위한 bool 변수


    private void Start()
    {
        cb = hpBar.colors;
        LevelUpdate();
    }

    void Update()
    {
        hpBar.value = (float)Player.instance.currentHP / (float)Player.instance.maxHP;

        // 체력이 0이 되면 코루틴 중지
        if(hpBar.value == 0)
        {
            StopCoroutine("AlphaBlink");
            cb.normalColor = new Color32(255, 255, 255, 255); // UI를 원래 색으로 되돌림
            hpBar.colors = cb;
        }

        // 체력이 낮을 때 체력바의 알파값이 깜빡임
        else if (hpBar.value < 0.3)
        {
            if (!isCoroutineStarted)
            {
                StartCoroutine("AlphaBlink");
                hpBar.colors = cb;
            }
        }
    }
        
    // 플레이어의 레벨을 얻어옴
    public void LevelUpdate()
    {
        level.text = Player.instance.level.ToString();
    }

    // 알파값 깜빡임 처리(빨간색)
    IEnumerator AlphaBlink()
    {
        isCoroutineStarted = true;

        int coolTime = 0;
        while (true)
        {
            if (coolTime % 2 == 0)
            {
                cb.normalColor = new Color32(255, 0, 0, 50);
                hpBar.colors = cb;
            }
            else
            {
                cb.normalColor = new Color32(255, 0, 0, 255);
                hpBar.colors = cb;
            }

            yield return new WaitForSeconds(0.25f);
            coolTime++;
        }
    }
}
