using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieExplosivo : Enemigo
{
    private Explosivo explosivo;


    protected override void Morir() { 
        explosivo.Explotar();
        Destroy(gameObject);
    
    }
  
}
