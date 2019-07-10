using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obj;
    public float[] objTimeInterval; // 생성 간격

    private int maxObj = 20; // 미리 생성해둘 오브젝트 수
    private ObjectPool[] objPool;

    private void Awake()
    {
        objPool = new ObjectPool[obj.Length];
        for (int i = 0; i < obj.Length; i++)
            objPool[i] = new ObjectPool();

        for (int i = 0; i < objPool.Length; i++)
            objPool[i].InitPool(obj[i], maxObj);
    }

    private void Start()
    {
        for(int i=0; i<obj.Length; i++)
        {
            StartCoroutine(SpawnObject(objPool[i], objTimeInterval[i]));
        }
    }

    IEnumerator SpawnObject(ObjectPool pool, float timeInterval)
    {
        while (true)
        {
            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            pool.GetObject(transform.position.x, randomY);
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
