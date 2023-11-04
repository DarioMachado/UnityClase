using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour, IDamageable
{
    
    public int vida;
    public float velocidad;
    public int dmg;
    public float rango; //Se refiere al rango de ataque de los enemigos.
    private Rigidbody rb;
    private Collider col;
    private Animator animator; //El nombre de las animaciones de los enemigos debe de ser consistente (ej: todas las animaciones de morir han de llamarse Morir o Die o lo que sea) 
    private GameObject jugador;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        jugador = GameObject.FindWithTag("Jugador"); //O como sea que se llame el tag de jugador.
    }
    
    public virtual void RecibirDMG(int dmg)
    {
        //F�rmula de da�o "cruda" que da por hecho que todos los enemigos tienen la misma defensa, y que los enemigos m�s "tanque" simplemente tienen m�s vida.
        //En caso de querer a�adir en un futuro diferentes sistemas (por ejemplo, reducir la defensa del enemigo, o hacer que los enemigos tengan
            //armadura, que pueda eliminarse de alguna forma) bastar�a con cambiar el c�lculo de abajo.
        //Para enemigos individuales, se puede crear en su script tambi�n un public override void RecibirDMG(int dmg) para hacerle el @Override de java a esta funci�n.
        vida -= dmg;

        if(vida < 0)
        {
            Morir();
        }

    }

    protected virtual void Morir()
    {
        //Antes de destruir el objeto, se podr�a poner aqu� algo de l�gica, como reproducir la animaci�n de muerte.
        //En caso de necesidad de a�adir l�gica m�s espec�fica, por ejemplo un enemigo que explote o eche �cido despu�s de morir,
        //se puede hacer un protected override void Morir() a este m�todo

        Destroy(gameObject);
    }
    //TODO: Pensar c�mo hacer esto.
    public void Atacar() {
    
    
    }

    //TODO: Implementar pathfinding, ahora mismo los zombies se chocar�an contra las paredes. Quiz� tambi�n un rango de activaci�n para que no te empiecen a seguir los zombies a 2 km.
    public void Caminar() {
        Vector3 direccionJugador = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
       
       transform.position = Vector3.Lerp(transform.position, direccionJugador, velocidad * Time.deltaTime);


    }




    public void Update()
    {
        Caminar();
        
    }



}
