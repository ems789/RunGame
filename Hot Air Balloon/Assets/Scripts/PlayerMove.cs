using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public int levitationSpeed = 200;
    public int moveSpeed = 5; // 초당 이동거리

    public float curDistance = 0;
    public float tempDistance = 0; // 거리 중간 저장
    public float targetDistance = 200; // 목표 이동 거리 = 경험치

    public Text distance;

    Animator anim;
       
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 죽으면 키 입력을 받지 않음
        if (Player.instance.isDead) 
        {
            anim.SetBool("isDead", true);
            return;
        }


        // 거리 체크
        curDistance += moveSpeed * Time.deltaTime;
        tempDistance = curDistance;
        distance.text = "거리 : " + (int)curDistance; // 소수점은 표시하지 않음
        if(tempDistance >= targetDistance)
        {
            tempDistance = 0;
            targetDistance *= 2;
            Player.instance.LevelUp();
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("isUp", true);
            // 일시 정지 상태에서 다시 게임 진행
            if (Time.timeScale == 0 && !Player.instance.isDead)
                Time.timeScale = 1;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(0, levitationSpeed, 0);
        }
        else
            anim.SetBool("isUp", false); // 하강

        // 이동 거리 제한
        if (transform.position.y >= Constant.maxHeight)
            transform.position = new Vector2(transform.position.x, Constant.maxHeight);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿으면 게임을 일시정지
        if(collision.transform.tag == "Ground")
        {
            if (!Player.instance.isDead)
            {
                anim.Rebind(); // 열기구 착지한것 처럼 보이도록 Idle 모션으로 애니메이션 리셋                
            }
            else if(Player.instance.isDead) // 죽어서 땅에 떨어지면
            {
                Player.instance.Resurrection(); // 부활
                // 애니메이션 초기화
                anim.SetBool("isDead", false);
                anim.Rebind();
            }
            Time.timeScale = 0;
        }
    }
}
