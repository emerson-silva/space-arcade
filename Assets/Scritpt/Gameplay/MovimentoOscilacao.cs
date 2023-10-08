using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoOscilacao : MonoBehaviour
{

    [SerializeField]
    private float amplitude;
    [SerializeField]
    private float velocidade;

    private Vector3 posicaoInicial;
    private float angulo;

    void Awake()
    {
        this.posicaoInicial = this.transform.position;
    }

    void Update()
    {
        this.angulo+=velocidade;
        var variacao = Mathf.Sin(angulo);
        this.transform.position = this.posicaoInicial + this.amplitude * variacao * Vector3.up;
    }
}
