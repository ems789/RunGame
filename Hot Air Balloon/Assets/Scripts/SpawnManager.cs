using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject air;
    public float airCreationInterval;

    private float airTimeChk;

    private void Start()
    {
        float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
        Instantiate(air, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity).transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        airTimeChk += Time.deltaTime;
        while (airTimeChk >= airCreationInterval)
        {
            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            Instantiate(air, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity).transform.SetParent(transform);
            airTimeChk = 0;
        }

    }
}
