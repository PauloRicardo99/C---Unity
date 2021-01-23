using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrawUI : MonoBehaviour
{
    public GameManager gameManager;
    public PlayersNamesUI playersNames;

    // Canvas
    public GameObject drawBtUI;
    public GameObject drawResultUI;
    public GameObject selecaoTimeUI;
    public GameObject countUI;

    public VoteUI voteUIScript;

    // Textos
    public TextMeshProUGUI jogador;
    public TextMeshProUGUI jogadorResult;
    public TextMeshProUGUI resultado;

    // Cores
    Color azul = new Color(0f, 0.588f, 1f);
    Color vermelho = new Color(0.725f, 0f, 0f);

    // Variáveis
    public int[] functions = { 1, 1, 1, 1, 1, 1, 1, 2, 2, 2 };             // 0 = OCUPADA, 1 = resistência, 2 = espião, 3 = comandante, 4 = assassino, 5 = guarda-costas, 6 = comandante falso
    public int sorteado;
    public int jogadoresComFuncao;


    // Define o vetor com as funções para o sorteio
    public void DefinirFunções()
    {
        sorteado = 0;
        jogadoresComFuncao = 0;

        int quantidade = gameManager.quantidadeJogadores;
        functions[0] = functions[1] = functions[2] = functions[3] = functions[4] = functions[5] = functions[6] = 1;
        functions[7] = functions[8] = functions[9] = 2;

        if (quantidade == 5)
        {
            functions[3] = functions[4] = functions[5] = functions[6] = functions[9] = 0;
        }
        else if (quantidade == 6)
        {
            functions[4] = functions[5] = functions[6] = functions[9] = 0;
        }
        else if (quantidade == 7)
        {
            functions[5] = functions[6] = functions[9] = 0;
        }
        else if (quantidade == 8)
        {
            functions[5] = functions[6] = 0;
        }
        else if (quantidade == 9)
        {
            functions[6] = 0;
        }

        if (gameManager.toggle2)
        {
            functions[0] = 3;
            functions[7] = 4;
        }
        if (gameManager.toggle3)
        {
            functions[1] = 5;
            functions[8] = 6;
        }

        jogador.SetText(playersNames.jogadores[jogadoresComFuncao]);
        jogadorResult.SetText(playersNames.jogadores[jogadoresComFuncao]);
    }


    // Sorteia as funções e chama o resultado
    public void Sorteio()
    {
        bool a = false;
        int index = Random.Range(0, 10);
        if (functions[index] != 0)
        {
            sorteado = functions[index];
            functions[index] = 0;
            a = true;
        }

        if (a == true) { Resultado(); }
        else { Sorteio(); }
    }
    public void Resultado()
    {
        switch (sorteado)
        {
            case 1:
                resultado.color = azul;
                resultado.SetText("resistência");
                break;
            case 2:
                resultado.color = vermelho;
                resultado.SetText("espião");
                break;
            case 3:
                resultado.color = azul;
                resultado.SetText("comandante");
                break;
            case 4:
                resultado.color = vermelho;
                resultado.SetText("assassino");
                break;
            case 5:
                resultado.color = azul;
                resultado.SetText("guarda-costas");
                break;
            case 6:
                resultado.color = vermelho;
                resultado.SetText("comandante falso");
                break;
        }

        jogadorResult.SetText(playersNames.jogadores[jogadoresComFuncao]);
        jogadoresComFuncao++;
        if (jogadoresComFuncao <= 9)
        {
            jogador.SetText(playersNames.jogadores[jogadoresComFuncao]);
        }

        drawBtUI.SetActive(false);
        drawResultUI.SetActive(true);
    }


    // Muda da tela de resultado pra tela de seleção de time ou volta para tela de sorteio
    public void OkBtResult()
    {
        if (jogadoresComFuncao == gameManager.quantidadeJogadores) 
        {
            drawResultUI.SetActive(false);
            countUI.SetActive(true);
            voteUIScript.votos.SetActive(false);
            selecaoTimeUI.SetActive(true);
        }
        else 
        {
            drawResultUI.SetActive(false);
            drawBtUI.SetActive(true);
        }
    }
}
