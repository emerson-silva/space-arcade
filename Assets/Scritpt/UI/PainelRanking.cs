using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelRanking : MonoBehaviour
{
    [SerializeField]
    private Ranking ranking;
    [SerializeField]
    private GameObject prefabColocacao;

    void Start()
    {
        ranking.PegarRecordes();
        int index = 0;
        foreach (Recorde recorde in ranking.PegarRecordes())
        {
            index++;
            InstanciarColocacao(recorde, index);
        }
    }

    private void InstanciarColocacao(Recorde recorde, int posicao)
    {
        Colocacao colocacao = GameObject.Instantiate(prefabColocacao, this.transform).GetComponent<Colocacao>();
        colocacao.Configurar(posicao, recorde.Nome(), recorde.Pontos());
    }

}
