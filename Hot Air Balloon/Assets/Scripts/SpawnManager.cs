﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject air;
    public float airCreationInterval;

    private float timeChk;

    private void Start()
    {
        float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
        Instantiate(air, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity).transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        timeChk += Time.deltaTime;
        while (timeChk >= airCreationInterval)
        {
            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            Instantiate(air, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity).transform.SetParent(transform);
            timeChk = 0;
        }

    }
}
