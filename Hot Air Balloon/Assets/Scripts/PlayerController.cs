using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public int hp = 100;
    public int levitationSpeed = 200;
    
    // 레벨
    // 현재 경험치, 필요 경험치
    private bool isDead = false;

    void Update()
    {      
        if(Input.GetMouseButton(0))
        {
            // 일시 정지 상태에서 다시 게임 진행
            if (Time.timeScale == 0 && isDead == false)
                Time.timeScale = 1;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(0, speed, 0);
        }

        // 체력이 시간마다 감소            
        // 체력이 0이 되면 사망 처리
        // 게임 매니저의 게임 오버 호출, 재시작 버튼 누르면 재시작
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿으면 게임을 멈춤
        if(collision.transform.tag == "Ground")
        {            
            Time.timeScale = 0;
        }
    }
}
