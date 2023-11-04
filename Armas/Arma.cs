using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public int dmg;
    public float cooldown; //Cómo de rápido puede atacar un arma, este sería un número bastante bajo para un arma automática por ejemplo, pero algo más alto para una escopeta
    public int municionMaxima; //Número de balas totales que puede llevar el arma, se puede eliminar
    private int _municionRestante; //Número restante de balas que posee el jugador en el arma. Cada vez que se recarga, disminuye.
    public int municionMaximaCargador; //El número máximo de balas que puede tener ese cargador.
    private int _municionActualCargador; //Balas que quedan en el cargador, cuando llega a 0 ya no se puede disparar más.
    private bool _recargando = false;
    private bool _disparando = false;
    public float duracionRecarga;
    

    //Aquí se pone la lógica de ataque de cada arma, dado cada arma tendrá una forma de atacar completamente diferente, no hay nada por defecto.
    public virtual void Atacar()
    {
        //blabla si municion es menor que 0, sonido de que faltan balas y return, si no, aplicar toda la lógica de disparo
        //Si recargando == true, return.
        //Llamar al cooldown, para que no puedas disparar 10 rpgs por segundo.
    }

    public void Recargar() 
    {


        if (_recargando)
            return;

        _recargando = true;
        //Aplicar animación de recarga aquí
        StartCoroutine(TiempoRecarga());
        //Terminar animación de recarga
        int balasARecargar = _municionActualCargador - municionMaximaCargador;
        _municionRestante -= balasARecargar;
        _municionActualCargador = municionMaximaCargador;
        if (_municionRestante < 0)
            _municionActualCargador += _municionRestante; //Es mucho más eficiente hacer esto, simplemente se recargan al máximo, y si el número de balas
                                                          //con las que te quedas es un número negativo, se te quitan todas las balas extras que has pillado.
        _recargando = false;
    }

    IEnumerator TiempoRecarga()
    {
        
        yield return new WaitForSeconds(duracionRecarga);
    }
    

    IEnumerator CoolDown()
    {
        _disparando = true;
        yield return new WaitForSeconds(cooldown);
        _disparando = false;
    }
   
}
