using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieExplosivo : Enemigo
{
    private Explosivo explosivo;

    //TODO: Implementar animación de muerte aquí
    protected override void Morir() { 
        explosivo.Explotar();
        Destroy(gameObject);
    
    }
  
}
