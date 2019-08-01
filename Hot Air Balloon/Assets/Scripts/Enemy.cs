using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    private float slowRate;

    // 태그를 확인하고 특수 효과 추가
    private void Start()
    {
        if (transform.tag == "Slow")
            slowRate = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Player.instance.isUnbeat)
        {
            if(transform.tag == "Slow") // 특수 효과가 있는 적이면
                PlayerMove.instance.StartCoroutine(PlayerMove.instance.SpeedDown(slowRate, 3f));
            Player.instance.GetDamage(damage);
        }
    }
}
