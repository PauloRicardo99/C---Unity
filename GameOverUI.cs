using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject gameOverUI;

    public TextMeshProUGUI vitoriaText;
    public TextMeshProUGUI mission1Text, mission2Text, mission3Text, mission4Text, mission5Text;

    // Cores
    Color vermelho = new Color(0.725f, 0f, 0f);
    Color azul = new Color(0f, 0.588f, 1f);


    public void GameOver()
    {
        if (gameManager.pontos[0] == 3) { vitoriaText.SetText("vitória da resistência"); vitoriaText.color = azul; }
        else { vitoriaText.SetText("vitória dos impostores"); vitoriaText.color = vermelho; }

        if (gameManager.resultadoMissoes[0] == 1) { mission1Text.color = azul; }
        else if (gameManager.resultadoMissoes[0] == 2){ mission1Text.color = vermelho; }
        if (gameManager.resultadoMissoes[1] == 1) { mission2Text.color = azul; }
        else if (gameManager.resultadoMissoes[1] == 2) { mission2Text.color = vermelho; }
        if (gameManager.resultadoMissoes[2] == 1) { mission3Text.color = azul; }
        else if (gameManager.resultadoMissoes[2] == 2) { mission3Text.color = vermelho; }
        if (gameManager.resultadoMissoes[3] == 1) { mission4Text.color = azul; }
        else if (gameManager.resultadoMissoes[3] == 2) { mission4Text.color = vermelho; }
        if (gameManager.resultadoMissoes[4] == 1) { mission5Text.color = azul; }
        else if (gameManager.resultadoMissoes[4] == 2) { mission5Text.color = vermelho; }

        gameManager.TudoInvisivel();
        gameOverUI.SetActive(true);
    }
}
