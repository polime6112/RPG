using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vs : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Attack;

    public void OnTriggerStay(Collider coll)
    {
        Attack.SetActive(true);
        if (coll.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.E))
        {
            Enemy.SetActive(false);
            Attack.SetActive(false);
        }
    }
}
