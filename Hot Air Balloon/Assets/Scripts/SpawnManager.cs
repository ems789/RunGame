using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject[] alphabet;
    public GameObject[] coinPattern;

    public GameObject attackPath;

    private GameObject[] path = new GameObject[2];

    public float[] objTimeInterval; // 오브젝트 생성 간격
    public float alphabetTimeInterval; // 알파벳 생성 간격
    public float coinTimeInterval;
    public float patternTimeInterval; // 패턴 사이의 간격

    // 미리 생성해둘 오브젝트 수
    private const int maxObj = 7; 
    private const int maxAlpha = 3; 
    private const int maxCoinPattern = 5;

    private const int patternRepeatCnt = 7; // 패턴 반복 횟수

    private ObjectPool[] objPool;
    private ObjectPool[] alphaPool;
    private ObjectPool[] coinPool;
    

    private void Awake()
    {
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = Instantiate(attackPath);
            path[i].SetActive(false); // 경로를 사용하기 전까지 꺼둠
        }

        // 필요한 만큼 배열에 공간 할당
        objPool = new ObjectPool[obj.Length];
        for (int i = 0; i < obj.Length; i++)
            objPool[i] = new ObjectPool();

        alphaPool = new ObjectPool[alphabet.Length];
        for (int i = 0; i < alphaPool.Length; i++)
            alphaPool[i] = new ObjectPool();

        coinPool = new ObjectPool[coinPattern.Length];
        for (int i = 0; i < coinPattern.Length; i++)
            coinPool[i] = new ObjectPool();

        // 풀 초기화
        for (int i = 0; i < objPool.Length; i++)
            objPool[i].InitPool(obj[i], maxObj);

        for (int i = 0; i < alphaPool.Length; i++)
            alphaPool[i].InitPool(alphabet[i], maxAlpha);

        for (int i = 0; i < coinPool.Length; i++)
            coinPool[i].InitPool(coinPattern[i], maxCoinPattern);
    }

    private void Start()
    {
        for(int i=0; i<obj.Length; i++)
        {
            StartCoroutine(SpawnObject(objPool[i], objTimeInterval[i]));                        
        }
        // 코인 생성
        StartCoroutine(SpawnCoin(coinPool, coinTimeInterval));

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

    // 코인은 패턴을 바꿔가며 생성하므로 생성 함수를 따로 뺌
    IEnumerator SpawnCoin(ObjectPool[] pool, float timeInterval)
    {
        // 패턴 랜덤
        while (true)
        {
            int randPattern = Random.Range(0, coinPattern.Length);

            // 패턴 반복 횟수
            for (int i = 0; i < patternRepeatCnt; i++)
            {
                // 패턴 생성, 패턴당 y랜덤
                float randY = Random.Range(Constant.minHeight + 2, Constant.maxHeight - 2);

                coinPool[randPattern].GetObject(transform.position.x, randY);

                // 동전 사이의 간격
                if (i < patternRepeatCnt - 1)
                    yield return new WaitForSeconds(timeInterval);
                // 패턴이 끝난 경우 다음 패턴까지의 간격
                else
                    yield return new WaitForSeconds(patternTimeInterval);
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
