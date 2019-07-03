using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obj;
    public float[] objTimeInterval;

    private void Start()
    {
        for(int i=0; i<obj.Length; i++)
        {
            StartCoroutine(SpawnObject(obj[i], objTimeInterval[i]));
        }
    }

    IEnumerator SpawnObject(GameObject obj, float timeInterval)
    {
        while (true)
        {
            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            Instantiate(obj, new Vector3(transform.position.x, randomY, 0f), Quaternion.identity).transform.SetParent(transform);
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
