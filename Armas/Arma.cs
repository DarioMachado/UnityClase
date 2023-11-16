using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public int dmg;
    public float cooldown; //C�mo de r�pido puede atacar un arma, este ser�a un n�mero bastante bajo para un arma autom�tica por ejemplo, pero algo m�s alto para una escopeta
    public int municionMaxima; //N�mero de balas totales que puede llevar el arma, se puede eliminar
    private int _municionRestante; //N�mero restante de balas que posee el jugador en el arma. Cada vez que se recarga, disminuye.
    public int municionMaximaCargador; //El n�mero m�ximo de balas que puede tener ese cargador.
    protected int _municionActualCargador; //Balas que quedan en el cargador, cuando llega a 0 ya no se puede disparar m�s.
    protected bool _recargando = false;
    protected bool _disparando = false;
    public float duracionRecarga;
    protected PoolingBalas _piscina;
   
    //Aqu� se pone la l�gica de ataque de cada arma, dado cada arma tendr� una forma de atacar completamente diferente, no hay nada por defecto.
    public abstract void Atacar();
    
        //blabla si municion es menor que 0, sonido de que faltan balas y return, si no, aplicar toda la l�gica de disparo
        //Si recargando == true, return.
        //Llamar al cooldown, para que no puedas disparar 10 rpgs por segundo.
    

    public void Recargar() 
    {


        if (_recargando)
            return;

        _recargando = true;
        //Aplicar animaci�n de recarga aqu�
        StartCoroutine(TiempoRecarga());
        //Terminar animaci�n de recarga
       
    }

    IEnumerator TiempoRecarga()
    {
        
        yield return new WaitForSeconds(duracionRecarga);


        int balasARecargar = municionMaximaCargador - _municionActualCargador;
        _municionRestante -= balasARecargar;
        _municionActualCargador = municionMaximaCargador;
        if (_municionRestante < 0)
        {
            _municionActualCargador += _municionRestante;
            _municionRestante = 0;    //Es mucho m�s eficiente hacer esto, simplemente se recargan al m�ximo, y si el n�mero de balas
        }                            //con las que te quedas es un n�mero negativo, se te quitan todas las balas extras que has pillado.
        _recargando = false;
    }
    

    protected IEnumerator CoolDown()
    {
        _disparando = true;
        yield return new WaitForSeconds(cooldown);
        _disparando = false;
    }


    protected void Iniciar()
    {
        _piscina = GameObject.FindObjectOfType<PoolingBalas>();
        _municionActualCargador = municionMaximaCargador;
        _municionRestante = municionMaxima;
    }
}

