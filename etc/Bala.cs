using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Crear un prefab de bala y añadirle este script. Para continuar, ir a PoolingBalas
 */
public class Bala : MonoBehaviour
{
 
   
    public float velocidad;
    private int dmg;
    private CapsuleCollider col;
    private bool moviendose;

    void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        col.enabled = false;
        velocidad = 40f;
    }


   
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("colison");
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
           
            damageable.RecibirDMG(dmg);

            Destruir();
            
        }
    }


    public void IniciarDisparo(int dmg, Transform tr)
    {
        this.dmg = dmg;
        Camera mainCamera = Camera.main;





        transform.position = tr.position;
        transform.forward = mainCamera.transform.forward;

        this.col.enabled = true;
        moviendose = true;

    }

    private void Update()
    {
        if (moviendose) {

            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        }
    }

    private void Destruir()
    {
        gameObject.SetActive(false);
        moviendose = false;
        this.col.enabled=false;
    }


}
