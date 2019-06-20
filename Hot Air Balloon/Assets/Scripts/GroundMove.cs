using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    private float width;

    void Start()
    {
        BoxCollider backgroundColider = GetComponent<BoxCollider>();
        width = backgroundColider.size.x * transform.localScale.x;
    }

    void Update()
    {
        if(transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        // 현재 위치에서 오른쪽으로 가로 길이 *2 만큼 이동
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
