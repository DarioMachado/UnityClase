using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieExplosivo : Enemigo
{
    private Explosivo explosivo;

    //TODO: Implementar animaci�n de muerte aqu�
    protected override void Morir() { 
        explosivo.Explotar();
        Destroy(gameObject);
    
    }
  
}
