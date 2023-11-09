using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour
{
    private const float RANGO_EXPLOSION = 5F;//Esto da por hecho que el rango de todos los explosivos serán iguales, puede ser cambiado luego quitando el const y creando getters y setters.
    private const int DMG_EXPLOSION = 60; //Lo mismo que el de arriba, pero con daño.
    public GameObject bolaExplosion;

    public void Explotar() {

        GameObject damageArea = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        damageArea.transform.position = transform.position;
        damageArea.transform.localScale = new Vector3(RANGO_EXPLOSION * 2, RANGO_EXPLOSION * 2, RANGO_EXPLOSION * 2);
        Renderer damageAreaRenderer = damageArea.GetComponent<Renderer>();
        damageAreaRenderer.GetComponent<Renderer>().material.color = new Color(1f, 0, 0, 0.2f);
        Destroy(damageArea, 1.2f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, RANGO_EXPLOSION); //Detecta todos los objetos con colliders en el rango de RANGO_EXPLOSIVO
        foreach (Collider collider in colliders) 
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.RecibirDMG(DMG_EXPLOSION);
            }

        }

    }

  
}
