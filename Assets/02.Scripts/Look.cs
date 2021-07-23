using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPosition;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "User") //User 태그를 가지고 있는 타겟 바라보기
        {
            targetPosition = new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z);
            transform.LookAt(targetPosition);
        }
    }
}