using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovaPontuacao : MonoBehaviour
{
    [SerializeField]
    private TextoDinamico textoPontuacao;
    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private Text textPlayerName;

    private int posicaoNovaPontuacao;
    private Pontuacao pontuacao;
    private readonly string PLAYER_NAME = "LastUsedName";

    private void Start()
    {
        int novaPontuacao = PegarPontuacao();
        textoPontuacao.AtualizarTexto(novaPontuacao);
        string nomeJogador = PegarNomeJogador();
        textPlayerName.text = nomeJogador;
        posicaoNovaPontuacao = ranking.AdicionarNovaPontuacao(nomeJogador, novaPontuacao);
    }

    private string PegarNomeJogador()
    {
        if (PlayerPrefs.HasKey(PLAYER_NAME))
        {
            return PlayerPrefs.GetString(PLAYER_NAME);
        }
        return "nome";
    }

    private int PegarPontuacao()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        if (pontuacao != null)
        {
            return pontuacao.Pontos;
        }
        return -1;
    }

    public void AtualizarNomeNovaPontuacao (string novoNome)
    {
        PlayerPrefs.SetString(PLAYER_NAME, novoNome);
        if (posicaoNovaPontuacao < ranking.PegarRecordes().Count)
        {
            ranking.AtualizarNomePontuacao(posicaoNovaPontuacao, novoNome);
        }
    }
}
