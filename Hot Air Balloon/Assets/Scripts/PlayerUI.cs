using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;
    public Text level;

    private void Start()
    {
        LevelUpdate();
    }

    void Update()
    {
        hpBar.value = (float)Player.instance.currentHP / (float)Player.instance.maxHP;
    }
        
    // 플레이어의 레벨을 얻어옴
    public void LevelUpdate()
    {
        level.text = Player.instance.level.ToString();
    }
}
