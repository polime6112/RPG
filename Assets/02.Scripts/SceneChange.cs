using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject UI;
    private void OnTriggerStay(Collider other) //각 태그에 따른 Collider와 충돌시 정해진 씬으로 이동
    {
        if(other.CompareTag("Play"))
        {
            SceneManager.LoadScene("Village");
        }
        else if (other.CompareTag("DF"))
        {
            SceneManager.LoadScene("Dungeon_Forest");
        }
        else if (other.CompareTag("DS"))
        {
            SceneManager.LoadScene("Dungeon_SnowMountain");
        }
        else if (other.CompareTag("DD"))
        {
            SceneManager.LoadScene("Dungeon_Desert");
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Start");
    }
}
