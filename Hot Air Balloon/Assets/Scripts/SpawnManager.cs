using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] alphabet;
    public float[] objTimeInterval; // 오브젝트 생성 간격
    public float alphabetTimeInterval; // 알파벳 생성 간격

    private int maxObj = 20; // 미리 생성해둘 오브젝트 수
    private int maxAlpha = 3; // 미리 생성해둘 오브젝트(알파벳) 수

    private ObjectPool[] objPool;
    private ObjectPool[] alphaPool;

    private void Awake()
    {
        objPool = new ObjectPool[obj.Length];
        for (int i = 0; i < obj.Length; i++)
            objPool[i] = new ObjectPool();

        alphaPool = new ObjectPool[alphabet.Length];
        for (int i = 0; i < alphaPool.Length; i++)
            alphaPool[i] = new ObjectPool();

        for (int i = 0; i < objPool.Length; i++)
            objPool[i].InitPool(obj[i], maxObj);

        for (int i = 0; i < alphaPool.Length; i++)
            alphaPool[i].InitPool(alphabet[i], maxAlpha);
    }

    private void Start()
    {
        for(int i=0; i<obj.Length; i++)
        {
            StartCoroutine(SpawnObject(objPool[i], objTimeInterval[i]));                        
        }
        // 알파벳 생성 
        StartCoroutine(SpawnAlphabet(alphaPool, alphabetTimeInterval));
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

    // 알파벳은 알파벳 목록 중에 하나를 랜덤으로 생성
    IEnumerator SpawnAlphabet(ObjectPool[] pool, float timeInterval)
    {
        while (true)
        {
            int rand = Random.Range(0, alphabet.Length);

            float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
            pool[rand].GetObject(transform.position.x, randomY);
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
