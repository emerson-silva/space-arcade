using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ranking : MonoBehaviour
{
    private const string NOME_ARQUIVO_RECORDES = "recordes.json";
    private string caminhoArquivo;

    [SerializeField]
    private List<Recorde> recordes;

    private void Awake()
    {
        caminhoArquivo = Path.Combine(Application.persistentDataPath, NOME_ARQUIVO_RECORDES);
        CarregarPontos();
        ImprimirPontos();
    }

    private void ImprimirPontos()
    {
        Debug.Log("recordes[" + recordes.Count + "]");
        foreach (Recorde recorde in recordes)
        {
            Debug.Log(" >> " + recorde.Nome() + " -> " + recorde.Pontos());
        }
    }

    public int AdicionarNovaPontuacao(string nome, int pontos)
    {
        return AdicionarNovaPontuacao(nome, pontos, false);
    }

    public int AdicionarNovaPontuacao(string nome, int pontos, bool destacar)
    {
        Debug.Log("Adicionar Pontos " + nome + " > " + pontos);
        Recorde novoRecorde = new Recorde(nome, pontos, destacar);
        recordes.Add(novoRecorde);
        recordes.Sort();
        SalvarPontos();
        return recordes.IndexOf(novoRecorde);
    }

    public void AtualizarNomePontuacao (int posicao, string novoNome)
    {
        if (posicao<0)
        {
            return;
        }
        Recorde[] tempRecordes = recordes.ToArray();
        (tempRecordes.GetValue(posicao) as Recorde).AtualizarNome(novoNome);
        ImprimirPontos();
        SalvarPontos();
    }

    public IReadOnlyList<Recorde> PegarRecordes()
    {
        Debug.Log("Pegar Recordes");
        return this.recordes;
    }

    private void CarregarPontos()
    {
        Debug.Log("Carregando Pontos...");
        if (File.Exists(caminhoArquivo))
        {
            var jsonPontos = File.ReadAllText(caminhoArquivo);
            JsonUtility.FromJsonOverwrite(jsonPontos, this);
        } else
        {
            recordes = new List<Recorde>();
        }
        Debug.Log("Pontos Carregados");
    }

    private void SalvarPontos ()
    {
        recordes = recordes.GetRange(0, 10);
        Debug.Log("Salvando Pontos...");
        string jsonPontos = JsonUtility.ToJson(this);
        File.WriteAllText(caminhoArquivo, jsonPontos);
        Debug.Log("Pontos Salvos");
    }
}
