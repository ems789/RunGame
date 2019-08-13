using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderCloud : MonoBehaviour
{
    private int alpha = 255;
    private int sign = 0; // 알파값이 증가or감소

    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        StartCoroutine("Shot");
    }

    private void OnEnable()
    {
        StartCoroutine("Shot");
    }

    IEnumerator Shot()
    {    
        while (true)
        {
            StartCoroutine("alphaBlink");
            yield return new WaitForSeconds(2f);

            ProjectlePool.ProjectilePool[0].GetObject(transform.position.x, transform.position.y);            
            yield return new WaitForSeconds(2f);
        }
    }

    // 알파값 깜빡임 처리

    IEnumerator alphaBlink()
    {
        int i = 0;
        while (i < 100)
        {
            Debug.Log(i);
            if (alpha == 120)
                sign = 5;
            else if (alpha == 255)
                sign = -5;

            alpha += sign;
            sprite.color = new Color32(255, 255, 255, (byte)alpha);

            yield return new WaitForSeconds(0.01f);
            i++;
        }
        
        sprite.color = new Color32(255, 255, 255, 255);
    }
}

