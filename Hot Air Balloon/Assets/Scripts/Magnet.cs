using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magneticForce = 2f;

    private void OnTriggerStay(Collider other)
    {        
        if (other.gameObject.layer == LayerMask.NameToLayer("Magnetic"))
        {
            // 일정 속도로 대상
            other.transform.position = Vector3.Lerp(other.transform.position, transform.position, magneticForce * Time.deltaTime); 

            // 대상과 거리가 근접한 경우
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if(distance <= 2.5f)
            {
                // 빠른 속도로 대상에 붙음
                other.transform.position = Vector3.Lerp(other.transform.position, transform.position, 10 * Time.deltaTime);
            }

        }
    }
}
