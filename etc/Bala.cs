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
    private Rigidbody rb;
    private Vector3 direccion;
    void Awake()
    {
        col = GetComponent<CapsuleCollider>();
        col.enabled = false;
        velocidad = 40f;
        rb = GetComponent<Rigidbody>();
    }


   
    void OnCollisionEnter(Collision collision)
    {
       
        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.RecibirDMG(dmg);
            
        }

        Destruir();
    }

    //Las balas rebotan.
    public void IniciarDisparo(int dmg, Transform tr, Vector3 direccion)
    {
        this.dmg = dmg;
       
        transform.position = tr.position;
        transform.rotation = tr.rotation;


        transform.forward = direccion.normalized;

        rb.velocity = transform.forward * 20f;
        this.col.enabled = true;
       
        StartCoroutine(TimeSpan());

    }

    private void Update()
    {
        
    }

    private void Destruir()
    {
        gameObject.SetActive(false);
       
        this.col.enabled=false;
    }

    IEnumerator TimeSpan()
    {
        

        
        yield return new WaitForSeconds(1.5f);
        Destruir();
     
    }
}
