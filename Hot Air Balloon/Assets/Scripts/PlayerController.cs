using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    Animator anim;

    public int levitationSpeed = 200;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Player.instance.isDead)
        {
            anim.SetBool("isDead", true);
            return;
        }

        if(Input.GetMouseButton(0))
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
            if(!Player.instance.isDead)
                anim.Rebind(); // 열기구 착지한것 처럼 보이도록 Idle 모션으로 애니메이션 리셋
            Time.timeScale = 0;
        }
    }

}
