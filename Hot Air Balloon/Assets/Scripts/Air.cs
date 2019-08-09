using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour
{
    public int recovery = 4;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlayOnce(SoundManager.instance.getItem);
            Player.instance.HPUp(recovery);
            gameObject.SetActive(false);
        }
    }
}
