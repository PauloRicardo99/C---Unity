using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarTime : MonoBehaviour
{
    public GameManager gameManager;
    public PlayersNamesUI playersNamesScript;
    public VoteUI voteUIScript;

    public GameObject selecaoTime;
    public GameObject count;
    public GameObject voteBt;
    public GameObject blockBt;
    public GameObject jogadores, j1, j2, j3, j4, j5, j6, j7, j8, j9, j10;

    public TextMeshProUGUI tj1, tj2, tj3, tj4, tj5, tj6, tj7, tj8, tj9, tj10;

    public int qtdSelecionados;
    public int[] selecionados;
    public string[] selecionadosNome;

    public Vector2 posicaoInicial;

    private Toggle toggle1, toggle2, toggle3, toggle4, toggle5, toggle6, toggle7, toggle8, toggle9, toggle10;
    private int aux;

    void Start()
    {
        toggle1 = j1.GetComponent<Toggle>();
        toggle2 = j2.GetComponent<Toggle>();
        toggle3 = j3.GetComponent<Toggle>();
        toggle4 = j4.GetComponent<Toggle>();
        toggle5 = j5.GetComponent<Toggle>();
        toggle6 = j6.GetComponent<Toggle>();
        toggle7 = j7.GetComponent<Toggle>();
        toggle8 = j8.GetComponent<Toggle>();
        toggle9 = j9.GetComponent<Toggle>();
        toggle10 = j10.GetComponent<Toggle>();
    }

    public void Atualizar()
    {
        AtualizarPosicao();
        AtualizarNomes();
    }

    public void AtualizarPosicao()
    {
        jogadores.transform.Translate(new Vector2(0, 0));

        switch (gameManager.quantidadeJogadores)
        {
            case 5:
                posicaoInicial = new Vector2(0, -200);
                j6.SetActive(false);
                j7.SetActive(false);
                j8.SetActive(false);
                j9.SetActive(false);
                j10.SetActive(false);
                break;
            case 6:
                posicaoInicial = new Vector2(0, -150);
                j6.SetActive(true);
                j7.SetActive(false);
                j8.SetActive(false);
                j9.SetActive(false);
                j10.SetActive(false);
                break;
            case 7:
                posicaoInicial = new Vector2(0, -80);
                j6.SetActive(true);
                j7.SetActive(true);
                j8.SetActive(false);
                j9.SetActive(false);
                j10.SetActive(false);
                break;
            case 8:
                posicaoInicial = new Vector2(0, -30);
                j6.SetActive(true);
                j7.SetActive(true);
                j8.SetActive(true);
                j9.SetActive(false);
                j10.SetActive(false);
                break;
            case 9:
                posicaoInicial = new Vector2(0, 70);
                j6.SetActive(true);
                j7.SetActive(true);
                j8.SetActive(true);
                j9.SetActive(true);
                j10.SetActive(false);
                break;
            case 10:
                posicaoInicial = new Vector2(0, 135);
                j6.SetActive(true);
                j7.SetActive(true);
                j8.SetActive(true);
                j9.SetActive(true);
                j10.SetActive(true);
                break;
        }

        jogadores.transform.localPosition = posicaoInicial;

    }

    public void AtualizarNomes()
    {
        tj1.SetText(playersNamesScript.jogadores[0]);
        tj2.SetText(playersNamesScript.jogadores[1]);
        tj3.SetText(playersNamesScript.jogadores[2]);
        tj4.SetText(playersNamesScript.jogadores[3]);
        tj5.SetText(playersNamesScript.jogadores[4]);
        tj6.SetText(playersNamesScript.jogadores[5]);
        tj7.SetText(playersNamesScript.jogadores[6]);
        tj8.SetText(playersNamesScript.jogadores[7]);
        tj9.SetText(playersNamesScript.jogadores[8]);
        tj10.SetText(playersNamesScript.jogadores[9]);
    }

    public void ResetToggle()
    {
        toggle1.isOn = true;
        toggle2.isOn = true;
        toggle3.isOn = true;
        toggle4.isOn = true;
        toggle5.isOn = true;
        toggle6.isOn = true;
        toggle7.isOn = true;
        toggle8.isOn = true;
        toggle9.isOn = true;
        toggle10.isOn = true;
        qtdSelecionados = 0;
        blockBt.SetActive(true);
    }

    public void AtualizarSelecionados()
    {
        selecionados = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        if (toggle1.isOn == false) { selecionados[0] = 1; }
        else { selecionados[0] = 0; }
        if (toggle2.isOn == false) { selecionados[1] = 1; }
        else { selecionados[1] = 0; }
        if (toggle3.isOn == false) { selecionados[2] = 1; }
        else { selecionados[2] = 0; }
        if (toggle4.isOn == false) { selecionados[3] = 1; }
        else { selecionados[3] = 0; }
        if (toggle5.isOn == false) { selecionados[4] = 1; }
        else { selecionados[4] = 0; }
        if (toggle6.isOn == false) { selecionados[5] = 1; }
        else { selecionados[5] = 0; }
        if (toggle7.isOn == false) { selecionados[6] = 1; }
        else { selecionados[6] = 0; }
        if (toggle8.isOn == false) { selecionados[7] = 1; }
        else { selecionados[7] = 0; }
        if (toggle9.isOn == false) { selecionados[8] = 1; }
        else { selecionados[8] = 0; }
        if (toggle10.isOn == false) { selecionados[9] = 1; }
        else { selecionados[9] = 0; }

        ResetToggle();
        AtualizarSelecionadosNome();
    }

    public void AtualizarSelecionadosNome()
    {
        switch (gameManager.quantidadeJogadoresMissao)
        {
            case 2:
                selecionadosNome = new string[] { "a", "b" };
                break;
            case 3:
                selecionadosNome = new string[] { "c", "d", "e" };
                break;
            case 4:
                selecionadosNome = new string[] { "f", "g", "h", "i" };
                break;
            case 5:
                selecionadosNome = new string[] { "j", "k", "l", "m", "n" };
                break;
        }

        aux = 0;
        for (int i=0; i<selecionados.Length; i++)
        {
            if (selecionados[i] == 1)
            {
                selecionadosNome[aux] = playersNamesScript.jogadores[i];
                aux++;
            }
        }
    }

    public void Toggle()
    {
        qtdSelecionados = 0;
        if (toggle1.isOn == false) { qtdSelecionados++; }
        if (toggle2.isOn == false) { qtdSelecionados++; }
        if (toggle3.isOn == false) { qtdSelecionados++; }
        if (toggle4.isOn == false) { qtdSelecionados++; }
        if (toggle5.isOn == false) { qtdSelecionados++; }
        if (toggle6.isOn == false) { qtdSelecionados++; }
        if (toggle7.isOn == false) { qtdSelecionados++; }
        if (toggle8.isOn == false) { qtdSelecionados++; }
        if (toggle9.isOn == false) { qtdSelecionados++; }
        if (toggle10.isOn == false) { qtdSelecionados++; }

        if (qtdSelecionados >= gameManager.quantidadeJogadoresMissao)
        {
            if (toggle1.isOn == true) { toggle1.interactable = false; }
            else { toggle1.interactable = true; }
            if (toggle2.isOn == true) { toggle2.interactable = false; }
            else { toggle2.interactable = true; }
            if (toggle3.isOn == true) { toggle3.interactable = false; }
            else { toggle3.interactable = true; }
            if (toggle4.isOn == true) { toggle4.interactable = false; }
            else { toggle4.interactable = true; }
            if (toggle5.isOn == true) { toggle5.interactable = false; }
            else { toggle5.interactable = true; }
            if (toggle6.isOn == true) { toggle6.interactable = false; }
            else { toggle6.interactable = true; }
            if (toggle7.isOn == true) { toggle7.interactable = false; }
            else { toggle7.interactable = true; }
            if (toggle8.isOn == true) { toggle8.interactable = false; }
            else { toggle8.interactable = true; }
            if (toggle9.isOn == true) { toggle9.interactable = false; }
            else { toggle9.interactable = true; }
            if (toggle10.isOn == true) { toggle10.interactable = false; }
            else { toggle10.interactable = true; }
        }
        else
        {
            toggle1.interactable = true;
            toggle2.interactable = true;
            toggle3.interactable = true;
            toggle4.interactable = true;
            toggle5.interactable = true;
            toggle6.interactable = true;
            toggle7.interactable = true;
            toggle8.interactable = true;
            toggle9.interactable = true;
            toggle10.interactable = true;
        }


        if (qtdSelecionados == gameManager.quantidadeJogadoresMissao) { blockBt.SetActive(false); }
        else { blockBt.SetActive(true); }

    }

    public void OkBtEvent()
    {
        gameManager.estagio = 1;
        voteUIScript.lider2 = gameManager.liderAtual;
        selecaoTime.SetActive(false);
        voteUIScript.votos.SetActive(true);
        count.SetActive(true);
        voteBt.SetActive(true);
    }
}
