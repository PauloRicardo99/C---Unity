using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoteUI : MonoBehaviour
{
    public GameManager gameManager;
    public GameOverUI gameOverUIScript;
    public PlayersNamesUI playersNames;
    public SelecionarTime selecionarTimeScript;

    // Canvas
    public GameObject voteBtUI;
    public GameObject voteUI;
    public GameObject countUI;
    public GameObject failUI;
    public GameObject resultUI;
    public GameObject selecionarTimeUI;
    public GameObject votos;

    // Missões e strikes
    public TextMeshProUGUI mission1Text, mission2Text, mission3Text, mission4Text, mission5Text;
    public TextMeshProUGUI strikeText1, strikeText2, strikeText3, strikeText4, strikeText5;

    public TextMeshProUGUI tipoVotacaoText;
    public TextMeshProUGUI votosRestantesText;
    public TextMeshProUGUI falhasText;
    public TextMeshProUGUI tamanhoDoTime;
    public TextMeshProUGUI positivoBtText;
    public TextMeshProUGUI negativoBtText;
    public TextMeshProUGUI resultadoText;
    public TextMeshProUGUI positivoText;
    public TextMeshProUGUI negativoText;
    public TextMeshProUGUI jogador;
    public TextMeshProUGUI lider;

    //Cores
    Color cinzaClaro = new Color(0.749f, 0.749f, 0.749f);
    Color cinzaEscuro = new Color(0.14f, 0.14f, 0.14f);
    Color vermelho = new Color(0.725f, 0f, 0f);
    Color azul = new Color(0f, 0.588f, 1f);

    public int votosPositivos;
    public int votosNegativos;
    public int votosFeitos;
    public int lider2 = 0;
    public bool resultado;

    public void Iniciar()
    {
        gameManager.missaoAtual = 1;
    }

    // Muda da tela VoteBt para Vote
    public void Votar()
    {
        if (gameManager.estagio == 1)
        {
            positivoBtText.SetText("aceitar");
            negativoBtText.SetText("recusar");
        }
        else if (gameManager.estagio == 2)
        {
            positivoBtText.SetText("sucesso");
            negativoBtText.SetText("fracasso");
        }

        voteBtUI.SetActive(false);
        voteUI.SetActive(true);
    }


    // Botões voto positivo ou negativo
    public void VotoPositivo()
    {
        votosPositivos++;
        votosFeitos++;
        Votado();
    }
    public void VotoNegativo()
    {
        votosNegativos++;
        votosFeitos++;
        Votado();
    }
    public void Votado()
    {
        AtualizarTextos();
        if (gameManager.estagio == 1)
        {
            if (votosNegativos >= (gameManager.quantidadeJogadores / 2))
            {
                resultado = false;
            }
            else
            {
                resultado = true;
            }

            if (votosFeitos == gameManager.quantidadeJogadores)
            {
                Resultado();
            }
            else
            {
                voteUI.SetActive(false);
                voteBtUI.SetActive(true);
            }
        }
        else if (gameManager.estagio == 2)
        {
            if (gameManager.quantidadeJogadores < 7)
            {
                if (votosNegativos > 0)
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }
            else
            {
                if ((gameManager.missaoAtual == 4 && votosNegativos > 1) || (gameManager.missaoAtual != 4 && votosNegativos > 0))
                {
                    resultado = false;
                }
                else
                {
                    resultado = true;
                }
            }

            if (votosFeitos == gameManager.quantidadeJogadoresMissao)
            {
                Resultado();
            }
            else
            {
                voteUI.SetActive(false);
                voteBtUI.SetActive(true);
            }
        }
    }


    // Após a votação exibe o resultado na tela
    public void Resultado()
    {
        if (gameManager.estagio == 1)
        {
            if (resultado) 
            { 
                resultadoText.SetText("tripulação aceita");
            }
            else 
            { 
                resultadoText.SetText("tripulação recusada");
            }

            positivoText.SetText("aceitar: " + votosPositivos);
            negativoText.SetText("recusar: " + votosNegativos);
        }
        else if (gameManager.estagio == 2)
        {
            if (resultado) 
            { 
                resultadoText.SetText("missão sucedida"); 
            }
            else 
            { 
                resultadoText.SetText("missão fracassada");
            }

            positivoText.SetText("sucesso: " + votosPositivos);
            negativoText.SetText("fracasso: " + votosNegativos);
        }

        votos.SetActive(false);
        voteUI.SetActive(false);
        resultUI.SetActive(true);
    }


    public void OkBtResultEvent()
    {
        ZerarVotos();
        switch (gameManager.estagio)
        {
            case 1:
                gameManager.PassarLider();
                if (resultado)
                {
                    strikeText1.color = cinzaEscuro;
                    strikeText2.color = cinzaEscuro;
                    strikeText3.color = cinzaEscuro;
                    strikeText4.color = cinzaEscuro;
                    strikeText5.color = cinzaEscuro;

                    gameManager.strikes = 0;
                    gameManager.estagio = 2;

                    AtualizarStrikes();
                    AtualizarTextos();

                    resultUI.SetActive(false);
                    votos.SetActive(true);
                    voteBtUI.SetActive(true);
                    countUI.SetActive(true);
                }
                else
                {
                    gameManager.strikes++;
                    resultUI.SetActive(false);
                    votos.SetActive(false);
                    selecionarTimeUI.SetActive(true);
                    AtualizarStrikes();
                    AtualizarTextos();
                }
                break;

            case 2:
                switch (gameManager.missaoAtual)
                {
                    case 1:
                        if (resultado) 
                        { 
                            mission1Text.color = azul;
                            gameManager.resultadoMissoes[0] = 1; 
                            gameManager.pontos[0]++;
                        }
                        else 
                        { 
                            mission1Text.color = vermelho;
                            gameManager.resultadoMissoes[0] = 2;
                            gameManager.pontos[1]++; 
                        }
                        break;
                    case 2:
                        if (resultado) 
                        { 
                            mission2Text.color = azul;
                            gameManager.resultadoMissoes[1] = 1;
                            gameManager.pontos[0]++; 
                        }
                        else 
                        { 
                            mission2Text.color = vermelho;
                            gameManager.resultadoMissoes[1] = 2;
                            gameManager.pontos[1]++; 
                        }
                        break;
                    case 3:
                        if (resultado) 
                        { 
                            mission3Text.color = azul;
                            gameManager.resultadoMissoes[2] = 1;
                            gameManager.pontos[0]++; 
                        }
                        else 
                        { 
                            mission3Text.color = vermelho;
                            gameManager.resultadoMissoes[2] = 2;
                            gameManager.pontos[1]++; 
                        }
                        break;
                    case 4:
                        if (resultado) 
                        { 
                            mission4Text.color = azul;
                            gameManager.resultadoMissoes[3] = 1;
                            gameManager.pontos[0]++; 
                        }
                        else 
                        { 
                            mission4Text.color = vermelho;
                            gameManager.resultadoMissoes[3] = 2;
                            gameManager.pontos[1]++; 
                        }
                        break;
                    case 5:
                        if (resultado) 
                        { 
                            mission5Text.color = azul;
                            gameManager.resultadoMissoes[4] = 1;
                            gameManager.pontos[0]++; 
                        }
                        else 
                        { 
                            mission5Text.color = vermelho;
                            gameManager.resultadoMissoes[4] = 2;
                            gameManager.pontos[1]++; 
                        }
                        break;
                }

                if (gameManager.pontos[0] == 3 || gameManager.pontos[1] == 3)
                {
                    gameOverUIScript.GameOver();
                }
                else
                {
                    gameManager.missaoAtual++;
                    gameManager.estagio = 1;

                    AtualizarStrikes();
                    AtualizarTextos();
                    selecionarTimeScript.Atualizar();
                    selecionarTimeScript.ResetToggle();

                    resultUI.SetActive(false);
                    votos.SetActive(false);
                    selecionarTimeUI.SetActive(true);
                }
                break;
        }
    }    
    public void OkBtFailEvent()
    {
        gameManager.estagio = 2;
        failUI.SetActive(false);
        OkBtResultEvent();
        gameManager.AtualizarQuantidadeJogadoresFalhasMissao();
        AtualizarTextos();
    }

    // Atualiza os strikes causados por tripulação recusada
    public void AtualizarStrikes()
    {
        switch (gameManager.strikes)
        {
            case 0:
                strikeText1.color = strikeText2.color = strikeText3.color = strikeText4.color = strikeText5.color = cinzaEscuro;
                break;
            case 1:
                strikeText1.color = vermelho;
                break;
            case 2:
                strikeText2.color = vermelho;
                break;
            case 3:
                strikeText3.color = vermelho;
                break;
            case 4:
                strikeText4.color = vermelho;
                break;
            case 5:
                strikeText5.color = vermelho;
                gameManager.strikes = 0;
                selecionarTimeUI.SetActive(false);
                resultUI.SetActive(false);
                voteBtUI.SetActive(false);
                countUI.SetActive(false);
                failUI.SetActive(true);
                break;
        }
    }
    // Atualiza os textos da tela Count
    public void AtualizarTextos()
    {
        gameManager.AtualizarQuantidadeJogadoresFalhasMissao();


        int votosRestantes = 0;

        if (gameManager.estagio == 1)
        {
            tipoVotacaoText.SetText("voto de tripulação");
            votosRestantes = gameManager.quantidadeJogadores - votosFeitos;
        }
        else if (gameManager.estagio == 2)
        {
            tipoVotacaoText.SetText("voto de missão");
            votosRestantes = gameManager.quantidadeJogadoresMissao - votosFeitos;
        }

        votosRestantesText.SetText("votos restantes: " + votosRestantes);
        falhasText.SetText(gameManager.falhasNecessarias.ToString());
        tamanhoDoTime.SetText(gameManager.quantidadeJogadoresMissao.ToString());
        lider.SetText("líder: " + playersNames.jogadores[gameManager.liderAtual]);

        if (votosFeitos < 10)
        {
            if (gameManager.estagio == 1) 
            {
                jogador.SetText(playersNames.jogadores[lider2]);
                lider2++;
                if (lider2 == gameManager.quantidadeJogadores) { lider2 = 0; }
            }
            else 
            {
                if (votosFeitos < gameManager.quantidadeJogadoresMissao)
                {
                    jogador.SetText(selecionarTimeScript.selecionadosNome[votosFeitos]);
                }
            }
        }
    }
    public void AtualizarMissoes()
    {
        mission2Text.color = mission3Text.color = mission4Text.color = mission5Text.color = cinzaEscuro;
    }

    // Zera os votos
    public void ZerarVotos()
    {
        votosFeitos = votosPositivos = votosNegativos = 0;
    }

    // Ressalta a missão atual na tela count
    public void RessaltarMissao()
    {
        switch (gameManager.missaoAtual)
        {
            case 0:
                mission1Text.color = mission2Text.color = mission3Text.color = mission4Text.color = mission5Text.color = cinzaEscuro;
                break;
            case 1:
                mission1Text.color = cinzaClaro;
                break;
            case 2:
                mission2Text.color = cinzaClaro;
                break;
            case 3:
                mission3Text.color = cinzaClaro;
                break;
            case 4:
                mission4Text.color = cinzaClaro;
                break;
            case 5:
                mission5Text.color = cinzaClaro;
                break;
        }
    }
}
