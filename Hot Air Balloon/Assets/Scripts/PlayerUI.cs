using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider hpBar;
    private Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        hpBar.value = (float)player.currentHP / (float)player.maxHP;
    }
}
