using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieExplosivo : Enemigo
{
    private Explosivo explosivo;



    //TODO: Implementar animación de muerte aquí
    protected override void Morir() {
        
        explosivo = gameObject.AddComponent<Explosivo>();
        Invoke("Detonar", 0.1f); //Bonito stack overflow te da si no haces esto

    }
    

    private void Detonar()
    {
        explosivo.Explotar();
        Destroy(gameObject);
    }
}
