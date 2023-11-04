using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public int dmg;
    public int municionMaxima; //N�mero de balas totales que puede llevar el arma, se puede eliminar
    private int _municionRestante; //N�mero restante de balas que posee el jugador en el arma. Cada vez que se recarga, disminuye.
    public int municionMaximaCargador; //El n�mero m�ximo de balas que puede tener ese cargador.
    private int _municionActualCargador; //Balas que quedan en el cargador, cuando llega a 0 ya no se puede disparar m�s.
    public Boolean recargando = false;
    public float duracionRecarga;

    //Aqu� se pone la l�gica de ataque de cada arma, dado cada arma tendr� una forma de atacar completamente diferente, no hay nada por defecto.
    public virtual void Atacar()
    {
        //blabla si municion es menor que 0, sonido de que faltan balas y return, si no, aplicar toda la l�gica de disparo
        //Si recargando == true, return.
    }

    public void Recargar() 
    {


        if (recargando)
            return;

        recargando = true;
        //Aplicar animaci�n de recarga aqu�
        TiempoRecarga();
        int balasARecargar = _municionActualCargador - municionMaximaCargador;
        _municionRestante -= balasARecargar;
        if (_municionRestante < 0)
            _municionActualCargador += _municionRestante; //Es mucho m�s eficiente hacer esto, simplemente se recargan al m�ximo, y si el n�mero de balas
                                                          //con las que te quedas es un n�mero negativo, se te quitan todas las balas extras que has pillado.
        recargando = false;
    }

    IEnumerator TiempoRecarga()
    {
        
        yield return new WaitForSeconds(duracionRecarga);
        

    }
    
   
}
