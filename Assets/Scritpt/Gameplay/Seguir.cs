using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;
    [SerializeField]
    private float forca;
    private Rigidbody2D fisica;

    private void Awake()
    {
        fisica = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (alvo!=null)
        {
            var vetorDif = alvo.position - transform.position;
            fisica.AddForce(vetorDif.normalized * forca, ForceMode2D.Force);
        }
    }

    public void SetAlvo (Transform alvo)
    {
        this.alvo = alvo;
    }
}
