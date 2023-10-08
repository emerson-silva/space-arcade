using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservaInimigos : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabInimigo;
    [SerializeField]
    private int tamanhoReserva;
    private Stack<GameObject> pilhaDeInimigos;

    // Start is called before the first frame update
    void Start()
    {
        pilhaDeInimigos = new Stack<GameObject>();
        for (int i = 0; i < this.tamanhoReserva; i++)
        {
            GameObject enemy = InstanciarNovoInimigo();
            this.pilhaDeInimigos.Push(enemy);
        }
    }

    public GameObject PegarInimigo()
    {
        if (this.pilhaDeInimigos.Count>0)
        {
            return this.pilhaDeInimigos.Pop();
        } else
        {
            return InstanciarNovoInimigo();
        }
    }

    private GameObject InstanciarNovoInimigo()
    {
        GameObject inimigo = GameObject.Instantiate(this.prefabInimigo, this.transform);
        inimigo.SetActive(false);
        inimigo.GetComponent<ObjetoDeReservaInimigos>().DefinitReserva(this);
        return inimigo;
    }

    public void DevolverInimigo(GameObject inimigo) {
        inimigo.SetActive(false);
        this.pilhaDeInimigos.Push(inimigo);
    }
}
