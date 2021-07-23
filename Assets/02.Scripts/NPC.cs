using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public Camera[] arrCam; //카메라 요소들 추가

    int nCamCount = 2;
    int nNowCam = 0;

    public GameObject UI;
    public GameObject PlayerUI;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC")) //NPC 태그를 가지고 있는 Collider안에서 E키 누르면 대화 생성
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ++nNowCam;

                if (nNowCam >= nCamCount)
                {
                    nNowCam = 0;
                }

                for (int i=0; i<arrCam.Length; ++i)
                {
                    arrCam[i].enabled = (i == nNowCam);
                }
                PlayerUI.SetActive(false);
                UI.SetActive(true);
            }
        }
    }
}
