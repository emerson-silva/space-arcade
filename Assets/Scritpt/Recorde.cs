using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Recorde : System.IComparable
{
    [SerializeField]
    private string nome;
    [SerializeField]
    private int pontos;
    [SerializeField]
    private bool destacar;

    public Recorde(string nome, int pontos, bool destacar)
    {
        this.nome = nome;
        this.pontos = pontos;
        this.destacar = destacar;
    }

    public Recorde(string nome, int pontos)
    {
        this.nome = nome;
        this.pontos = pontos;
    }

    public string Nome()
    {
        return nome;
    }

    public void AtualizarNome(string novoNome)
    {
        nome = novoNome;
    }

    public int Pontos()
    {
        return pontos;
    }

    public bool Destacar { get => destacar; set => destacar = value; }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Recorde outroRecorde = obj as Recorde;
        if(obj!=null)
        {
            if (pontos==outroRecorde.pontos)
            {
                return nome.CompareTo(outroRecorde.Nome());
            } else
            {
                return pontos.CompareTo(outroRecorde.Pontos()) *-1;
            }
        }
        else
        {
            throw new System.ArgumentException("Object is not a Recorde");
        }
    }

}