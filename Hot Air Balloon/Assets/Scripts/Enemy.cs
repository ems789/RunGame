﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    // enum으로 타입 구분, 타입별 효과 추가

    private void Start()
    {
        StartCoroutine(Disabled(8f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Player.instance.isUnbeat)
        {
            Player.instance.GetDamage(damage);
        }
    }

    IEnumerator Disabled(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
