using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Esta interfaz se a�ade a todos los "elementos" que puedan recibir da�o, esto incluye el jugador, los enemigos, barriles explosivos, puertas destruibles, cajas, etc..
 */
public interface IDamageable
{

    public void RecibirDMG(int dmg);
    
}
