using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject air;
    private float airTime = 3.0f;

    private float timeChk;

    // Update is called once per frame
    void Update()
    {
        timeChk += Time.deltaTime;
        while (timeChk >= airTime)
        {
            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            Instantiate(air, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity);
            timeChk = 0;
        }

    }
}
