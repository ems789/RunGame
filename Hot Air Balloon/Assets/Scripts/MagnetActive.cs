using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetActive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            // 플레이어의 자기장을 활성화
            Player.instance.GetComponentInChildren<Magnet>().StartCoroutine("MagnetFieldActive"); 
        }
    }

    

}
