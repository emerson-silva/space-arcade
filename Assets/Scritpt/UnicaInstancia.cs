using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    public static GameObject Instancia;
    [SerializeField]
    private bool destruirObjetoExistente;

    private void Start()
    {
        var outrasInstancias = GameObject.FindGameObjectsWithTag(this.tag);
        foreach(var instancia in outrasInstancias)
        {
            if (this.gameObject != instancia.gameObject)
            {
                GameObject.Destroy((destruirObjetoExistente)?instancia:this.gameObject);
            }
        }
    }
}
