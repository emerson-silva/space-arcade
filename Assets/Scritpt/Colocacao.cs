using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colocacao : MonoBehaviour
{
    [SerializeField]
    private Text posicao;
    [SerializeField]
    private Text nome;
    [SerializeField]
    private Text pontuacao;

    public void Configurar(int posicao, string nome, int pontos)
    {
        this.posicao.text = "" + posicao;
        this.nome.text = nome;
        this.pontuacao.text = "" + pontos;
    }
}
