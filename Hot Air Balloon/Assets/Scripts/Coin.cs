using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinScore; // 코인별 점수 구분

    private void Start()
    {
        StartCoroutine(Disabled(8f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.GetCoin(coinScore);
            gameObject.SetActive(false);
        }
    }

    IEnumerator Disabled(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
