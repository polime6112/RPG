using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject Set;
    public GameObject Main;

    public void OnClick()
    {
        Main.SetActive(false);
        Set.SetActive(true);
    }

    public void Click()
    {
        Set.SetActive(false);
        Main.SetActive(true);
    }
}
