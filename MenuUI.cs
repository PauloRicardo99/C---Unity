using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    // Canvas
    public GameObject menuUI;
    public GameObject configUI;



    // Muda para a tela Config
    public void LocalBt()
    {
        menuUI.SetActive(false);
        configUI.SetActive(true);
    }
}
