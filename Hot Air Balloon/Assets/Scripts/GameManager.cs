using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // 게임의 속도 조절을 위한 두 스크립트
    public PlayerMove playerMove;
    public ScrollingObject scrollingObject;

    public GameObject gameResultBoard;
    public Text distanceScore;
    public Text coinScore;
    public Text totalScore;

    const int scorePerCoin = 100;
    const int scorePerDistance = 20;

    public Text coinNum;
    private int coin;

    public bool isPause = false; // 키입력을 무시하는 일시정지 상태

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        
        Screen.SetResolution(800, 480, false); // 스크린 해상도 고정
        Application.targetFrameRate = 60; // 게임 프레임을 60으로 설정
    }

    public void GetCoin(int coinValue)
    {
        coin += coinValue;
        coinNum.text = coin.ToString();
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.8f);

        // 플레이어가 가지고 있는 PlayerMove 스크립트에서 이동한 거리를 불러옴
        int distance = (int)GameObject.Find("Player").GetComponent<PlayerMove>().curDistance;
        // 점수를 계산하고 결과창을 띄움
        distanceScore.text = (distance * scorePerDistance).ToString();
        coinScore.text = (coin * scorePerCoin).ToString();
        totalScore.text = "Total Score : " + ((distance * scorePerDistance) + (coin * scorePerCoin)).ToString();
        gameResultBoard.SetActive(true);
        Time.timeScale = 0;
    }
}
