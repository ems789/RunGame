using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 5f;
    private float tempSpeed = 0;

    private void Start()
    {
        tempSpeed = speed;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Stop()
    {
        speed = 0;
    }

    public void Restart()
    {
        speed = tempSpeed;
    }
}
