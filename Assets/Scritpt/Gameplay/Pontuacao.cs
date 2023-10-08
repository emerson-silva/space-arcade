using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pontuacao : MonoBehaviour
{
    public int Pontos { get {
            return pontos;
        }
    }

    private int pontos;
    [SerializeField]
    private EventoTextoDinamico aoPontuar;

    public void Pontuar()
    {
        pontos++;
        this.aoPontuar.Invoke(pontos);
    }

}

[System.Serializable]
public class EventoTextoDinamico : UnityEvent<int>
{

}
