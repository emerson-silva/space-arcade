using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gerador : MonoBehaviour
{
    [SerializeField]
    private float tempo;
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private Pontuacao pontuacao;
    [SerializeField]
    private ControleDePause controlePause;
    [SerializeField]
    private ReservaInimigos reservaInimigos;
    [SerializeField]
    private Rect areaSpawn;

    private void Start()
    {
        GameObject controlePausaGO = GameObject.FindGameObjectWithTag("ControleDePausa");
        if (controlePausaGO != null)
        {
            this.controlePause = controlePausaGO.GetComponent<ControleDePause>();
        }
        if (!JogoPausado())
        {
            StartSpawning();
        }
    }

    private void Update()
    {
        if (IsInvoking(nameof(Instanciar)) && JogoPausado())
        {
            StopSpawning();
        } else if (!IsInvoking(nameof(Instanciar)) && !JogoPausado())
        {
            StartSpawning();
        }
    }

    private void Instanciar()
    {
        var inimigo = this.reservaInimigos.PegarInimigo();
        this.DefinirPosicaoInimigo(inimigo);
        inimigo.GetComponent<Seguir>().SetAlvo(alvo);
        inimigo.GetComponent<Pontuavel>().SetPontuacao(pontuacao);
        inimigo.SetActive(true);
    }

    private void DefinirPosicaoInimigo(GameObject inimigo)
    {
        var posicaoAleatoria = new Vector3(
                        Random.Range(this.areaSpawn.x, this.areaSpawn.x + this.areaSpawn.width),
                        Random.Range(this.areaSpawn.y, this.areaSpawn.y + this.areaSpawn.height),
                        0);

        var posicaoInimigo = this.transform.position + posicaoAleatoria;
        inimigo.transform.position = posicaoInimigo;
    }

    private void StartSpawning()
    {
        InvokeRepeating(nameof(Instanciar), 0, tempo);
    }

    private void StopSpawning ()
    {
        CancelInvoke(nameof(Instanciar));
    }

    private bool JogoPausado()
    {
        return this.controlePause != null && controlePause.JogoEstaPausado();
    }

    private void OnDrawGizmos()
    {
        Vector2 posicaoDesenho = (Vector2) this.transform.position + areaSpawn.position + (areaSpawn.size / 2);
        Gizmos.color = new Color(100, 0, 100);
        Gizmos.DrawWireCube(posicaoDesenho, areaSpawn.size);
    }
}
