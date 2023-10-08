using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDeReservaInimigos : MonoBehaviour
{
    private ReservaInimigos reserva;

    public void DefinitReserva  (ReservaInimigos reserva) {
        this.reserva = reserva;
    }

    public void DevolverParaReserva()
    {
        this.reserva.DevolverInimigo(this.gameObject);
    }
}
