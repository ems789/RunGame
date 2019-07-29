using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] alphabet;

    public GameObject attackPath;

    private GameObject[] path = new GameObject[2];

    public float[] objTimeInterval; // 오브젝트 생성 간격
    public float alphabetTimeInterval; // 알파벳 생성 간격

    private int maxObj = 20; // 미리 생성해둘 오브젝트 수
    private int maxAlpha = 3; // 미리 생성해둘 오브젝트(알파벳) 수

    private ObjectPool[] objPool;
    private ObjectPool[] alphaPool;
    private ObjectPool airplanePool;

    private void Awake()
    {
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Instantiate(attackPath);
            path[i].SetActive(false); // 경로를 사용하기 전까지 꺼둠
        }

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
            // 비행기일경우 경로를 미리 띄워주기 위함
            if (pool.PeekObject().tag == "Airplane")
            {
                // 비행기는 게임 시작하고 일정 시간 경과후부터 생성됨 
                yield return new WaitForSeconds(timeInterval);

                float[] randomYArr = new float[2];
                for (int i = 0; i < path.Length; i++)
                {
                    path[i].SetActive(true);
                    randomYArr[i] = Random.Range(Constant.minHeight, Constant.maxHeight);
                    path[i].transform.position = new Vector3(transform.position.x, randomYArr[i], transform.position.z);
                }
                yield return new WaitForSeconds(3f);

                // 표시해둔 경로를 제거한 뒤 적을 생성
                for (int j = 0; j < path.Length; j++)
                {
                    path[j].SetActive(false);
                    pool.GetObject(transform.position.x, randomYArr[j]);
                }
            }
            // 비행기가 아닌 경우(경로 생성 코드x)
            else
            {
                float randomY = Random.Range(Constant.minHeight, Constant.maxHeight);
                pool.GetObject(transform.position.x, randomY);
                yield return new WaitForSeconds(timeInterval);
            }
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
