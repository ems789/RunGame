using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public void ForceGameOver()
    {
        Player.instance.isDead = true;
        GameManager.instance.StartCoroutine("GameOver");
        //GetComponentInParent<Canvas>().gameObject.SetActive(false);
    }
}
