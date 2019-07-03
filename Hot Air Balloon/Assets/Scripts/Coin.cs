using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinScore; // 코인별 점수 구분

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.GetCoin(coinScore);
            Destroy(gameObject);
        }
    }
}
