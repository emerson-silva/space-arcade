using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControleDePause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField, Range(0,1)]
    private float escalaDeTempoDurantePause;
    private bool jogoEstaParado;

    void Update()
    {
        Debug.Log("EstaTocandoNaTela? " + EstaTocandoNaTela());
        if (EstaTocandoNaTela())
        {
            if (jogoEstaParado)
            {
                ContinuarJogo();
            }
        } else
        {
            if (!jogoEstaParado)
            {
                PausarJogo();
            }
        }
    }

    private void ContinuarJogo()
    {
        StartCoroutine(EsperarParaContinuarJogo());
    }

    private IEnumerator EsperarParaContinuarJogo()
    {
        yield return  new WaitForSecondsRealtime(0.2f);
        jogoEstaParado = false;
        pauseMenu.SetActive(false);
        MudarEscalaDeTempo(1);
    }

    private void PausarJogo()
    {
        jogoEstaParado = true;
        pauseMenu.SetActive(true);
        MudarEscalaDeTempo(escalaDeTempoDurantePause);
    }

    private bool EstaTocandoNaTela () {
        if (PlataformaManager.IsRunningOnMobile())
        {

            return Input.touchCount>0;
        } else
        {
            Debug.Log("Fire1? " + Input.GetButton("Fire1"));
            return Input.GetButton("Fire1");
        }
    }

    private void MudarEscalaDeTempo(float escala)
    {
        Time.timeScale = escala;
        Time.fixedDeltaTime = 0.02f * escala;
    }

    public bool JogoEstaPausado ()
    {
        return jogoEstaParado;
    }
}
