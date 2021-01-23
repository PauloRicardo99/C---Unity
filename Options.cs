using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject exitConfirme, homeBt;
    public GameObject menuUI;

    void Start()
    {
        menuOff();
        homeBtOff();
    }


    public void yesBt()
    {
        gameManager.TudoInvisivel();
        gameManager.ResetarJogo();
        menuUI.SetActive(true);
    }
    public void menuOn()
    {
        exitConfirme.SetActive(true);
    }
    public void menuOff()
    {
        exitConfirme.SetActive(false);
    }
    public void homeBtOn()
    {
        homeBt.SetActive(true);
    }
    public void homeBtOff()
    {
        homeBt.SetActive(false);
    }
}
