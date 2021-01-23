using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigUI : MonoBehaviour
{
    public GameManager gameManager;

    // Canvas
    public GameObject configUI;
    public GameObject playerNamesUI;

    public GameObject blockToggle2, blockToggle3;
    public Toggle toggle2, toggle3;

    public TextMeshProUGUI jogadoresText, resistenciaText, espioesText;

    private int quantidadeResistencia = 3;
    private int quantidadeEspioes = 2;

    // Muda para a tela PlayersNames
    public void OkBt()
    {
        configUI.SetActive(false);
        playerNamesUI.SetActive(true);
    }


    // Define a quantidade de jogadores
    public void SliderEvent(float playersQtd)
    {
        switch (playersQtd)
        {
            case 5:
                quantidadeResistencia = 3;
                break;

            case 6:
                quantidadeResistencia = 4;
                break;
            case 7:
                quantidadeResistencia = 5;
                break;
            case 8:
                quantidadeResistencia = 5;
                break;
            case 9:
                quantidadeResistencia = 6;
                break;
            case 10:
                quantidadeResistencia = 7;
                break;
        }
        quantidadeEspioes = (int)playersQtd - quantidadeResistencia;
        gameManager.quantidadeJogadores = (int)playersQtd;

        jogadoresText.SetText(playersQtd.ToString() + " jogadores");
        resistenciaText.SetText(quantidadeResistencia.ToString());
        espioesText.SetText(quantidadeEspioes.ToString());
    }


    // Define se a opção para sortear funções está habilitada
    public void Toggle1Event(bool isOn)
    {
        if (isOn) 
        { 
            blockToggle2.SetActive(false); 
        }
        else 
        { 
            blockToggle2.SetActive(true); 
            toggle2.isOn = false; 
            toggle3.isOn = false;
            gameManager.toggle2 = false;
            gameManager.toggle3 = false;
        }
        gameManager.toggle1 = isOn;
    }


    // Define se a comandante e assassino estão habilitados
    public void Toggle2Event(bool isOn)
    {
        if (isOn) 
        {
            blockToggle3.SetActive(false);
        }
        else 
        { 
            blockToggle3.SetActive(true); 
            toggle3.isOn = false;
            gameManager.toggle3 = false;
        }
        gameManager.toggle2 = isOn;

    }


    // Define se a guarda costas e comandante falso estão habilitados
    public void Toggle3Event(bool isOn)
    {
        gameManager.toggle3 = isOn;
    }
}
