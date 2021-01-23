using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayersNamesUI : MonoBehaviour
{
    public GameManager gameManager;
    public VoteUI voteUIScript;

    // Canvas
    public GameObject playerNamesUI;
    public GameObject drawBtUI;
    public GameObject selecaoTimeUI;
    public GameObject countUI;

    public Image blockInput;

    // Caixas de texto
    public TMP_InputField input1, input2, input3, input4, input5, input6, input7, input8, input9, input10;

    // String que armazena o nome dos jogadores
    public string[] jogadores = { "Jogador  1", "Jogador  2", "Jogador  3", "Jogador  4", "Jogador  5", "Jogador  6", "Jogador  7", "Jogador  8", "Jogador  9", "Jogador  10" };



    // Muda para a tela de sorteio ou seleção de time
    public void okBtEvent()
    {
        if (gameManager.liderAtual >= gameManager.quantidadeJogadores) { gameManager.liderAtual = 0; }
        gameManager.ResetarJogo();
        AtualizaNomes();
        voteUIScript.AtualizarTextos();
        voteUIScript.AtualizarStrikes();

        // Muda para a tela de sorteio
        if (gameManager.toggle1)
        {
            playerNamesUI.SetActive(false);
            drawBtUI.SetActive(true);
        }
        // Muda para a tela de seleção de time
        else
        {
            playerNamesUI.SetActive(false);
            voteUIScript.votos.SetActive(false);
            countUI.SetActive(true);
            selecaoTimeUI.SetActive(true);
        }
    }


    // Atualiza o nome dos jogadores
    public void AtualizaNomes()
    {
        if (input1.text == "" || input1.text == null) { jogadores[0] = "Jogador 1"; }
        else { jogadores[0] = input1.text; }
        if (input2.text == "" || input2.text == null) { jogadores[1] = "Jogador 2"; }
        else { jogadores[1] = input2.text; }
        if (input3.text == "" || input3.text == null) { jogadores[2] = "Jogador 3"; }
        else { jogadores[2] = input3.text; }
        if (input4.text == "" || input4.text == null) { jogadores[3] = "Jogador 4"; }
        else { jogadores[3] = input4.text; }
        if (input5.text == "" || input5.text == null) { jogadores[4] = "Jogador 5"; }
        else { jogadores[4] = input5.text; }
        if (input6.text == "" || input6.text == null) { jogadores[5] = "Jogador 6"; }
        else { jogadores[5] = input6.text; }
        if (input7.text == "" || input7.text == null) { jogadores[6] = "Jogador 7"; }
        else { jogadores[6] = input7.text; }
        if (input8.text == "" || input8.text == null) { jogadores[7] = "Jogador 8"; }
        else { jogadores[7] = input8.text; }
        if (input9.text == "" || input9.text == null) { jogadores[8] = "Jogador 9"; }
        else { jogadores[8] = input9.text; }
        if (input10.text == "" || input10.text == null) { jogadores[9] = "Jogador 10"; }
        else { jogadores[9] = input10.text; }
    }


    // Bloqueia a quantidade de não jogadores 
    public void visibilidade()
    {
        switch (gameManager.quantidadeJogadores)
        {
            case 5:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 969.0001f);
                blockInput.rectTransform.localPosition = new Vector2(0, -517);
                break;
            case 6:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 769.0001f);
                blockInput.rectTransform.localPosition = new Vector2(0, -617);
                break;
            case 7:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 569.0001f);
                blockInput.rectTransform.localPosition = new Vector2(0, -716.9994f);
                break;
            case 8:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 369.0001f);
                blockInput.rectTransform.localPosition = new Vector2(0, -816.9994f);
                break;
            case 9:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 169.0001f);
                blockInput.rectTransform.localPosition = new Vector2(0, -916.9994f);
                break;
            case 10:
                blockInput.rectTransform.sizeDelta = new Vector2(1279.001f, 0);
                blockInput.rectTransform.localPosition = new Vector2(0, -1001.499f);
                break;
        }
    }
}
