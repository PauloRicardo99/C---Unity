using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Canvas
    public GameObject menuUI;
    public GameObject configUI;
    public GameObject voteBtUI;
    public GameObject voteUI;
    public GameObject resultUI;
    public GameObject countUI;
    public GameObject gameOverUI;
    public GameObject drawBtUI;
    public GameObject drawResultUI;
    public GameObject failUI;
    public GameObject playerNamesUI;
    public GameObject optionsUI;
    public GameObject selecaoTimeUI;

    public VoteUI voteUIScript;


    public int quantidadeJogadores = 5;
    public int missaoAtual;
    public int liderAtual;
    public int quantidadeJogadoresMissao;
    public int falhasNecessarias;
    public int strikes;
    public int estagio;                                 // 1 = time ou 2 = missao


    public int[] resultadoMissoes = { 0, 0, 0, 0, 0 };  // 1 = resistência ou 2 = espiões
    public int[] pontos = { 0, 0 };                     // resistência e espiões


    public bool toggle1 = false;                        // Sortear funções
    public bool toggle2 = false;                        // Comandante e assassino
    public bool toggle3 = false;                        // guarda-costas e comandante falso

    void Start()
    {
        TudoInvisivel();
        ResetarJogo();
        menuUI.SetActive(true);
        optionsUI.SetActive(true);
    }

    public void TudoInvisivel()
    {
        menuUI.SetActive(false);
        configUI.SetActive(false);
        voteBtUI.SetActive(false);
        voteUI.SetActive(false);
        resultUI.SetActive(false);
        countUI.SetActive(false);
        gameOverUI.SetActive(false);
        drawBtUI.SetActive(false);
        drawResultUI.SetActive(false);
        failUI.SetActive(false);
        playerNamesUI.SetActive(false);
        selecaoTimeUI.SetActive(false);
    }

    // Reseta as variáveis do jogo
    public void ResetarJogo()
    {
        missaoAtual = 1;
        strikes = 0;
        resultadoMissoes[0] = resultadoMissoes[1] = resultadoMissoes[2] = resultadoMissoes[3] = resultadoMissoes[4] = pontos[0] = pontos[1] = 0;
        estagio = 1;
        voteUIScript.ZerarVotos();
        voteUIScript.AtualizarMissoes();
    }


    // Atualiza a quantidade de jogadores e falhas necessárias numa missão
    public void AtualizarQuantidadeJogadoresFalhasMissao()
    {
        switch (quantidadeJogadores)
        {
            case 5:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 2; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 2; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                break;
            case 6:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 2; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                break;
            case 7:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 4; falhasNecessarias = 2; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                break;
            case 8:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 5; falhasNecessarias = 2; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 5; falhasNecessarias = 1; }
                break;
            case 9:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 5; falhasNecessarias = 2; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 5; falhasNecessarias = 1; }
                break;
            case 10:
                if (missaoAtual == 1) { quantidadeJogadoresMissao = 3; falhasNecessarias = 1; }
                else if (missaoAtual == 2) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 3) { quantidadeJogadoresMissao = 4; falhasNecessarias = 1; }
                else if (missaoAtual == 4) { quantidadeJogadoresMissao = 5; falhasNecessarias = 2; }
                else if (missaoAtual == 5) { quantidadeJogadoresMissao = 5; falhasNecessarias = 1; }
                break;
        }
    }


    public void PassarLider()
    {
        liderAtual++;
        if (liderAtual == quantidadeJogadores) { liderAtual = 0; }
    }
}
