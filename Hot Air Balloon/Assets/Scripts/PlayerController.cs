using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public int levitationSpeed = 200;

    Animator anim;
    
    // 레벨
    // 현재 경험치, 필요 경험치
    private bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHP = maxHP;

        // 체력이 지속적으로 감소
        StartCoroutine("HPDown");
    }

    void Update()
    {      
        if(Input.GetMouseButton(0))
        {
            anim.SetBool("isUp", true);
            // 일시 정지 상태에서 다시 게임 진행
            if (Time.timeScale == 0 && isDead == false)
                Time.timeScale = 1;

            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().AddForce(0, levitationSpeed, 0);
        }
        else
            anim.SetBool("isUp", false);


        // 체력이 0이 되면 사망 처리
        // 게임 매니저의 게임 오버 호출, 재시작 버튼 누르면 재시작
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 땅에 닿으면 게임을 멈춤
        if(collision.transform.tag == "Ground")
        {
            anim.Rebind();
            Time.timeScale = 0;
        }
    }

    IEnumerator HPDown()
    {
        while (currentHP > 0)
        {
            currentHP -= 1;
            yield return new WaitForSeconds(0.5f);
        }        
    }
}
