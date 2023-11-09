using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistola : Arma
{
   

    public override void Atacar()
    {
       
        if (_disparando) return;
        
        if (_recargando) return;
        

        if (_municionActualCargador == 0)
        {
           //Sonido de que faltan balas??? llamar a la función recargar aquí??? llamar siempre a recargar a menos que tengas 0 balas totales, en ese caso suena el sonidito???
            return;
        }

        //blabla si municion es menor que 0, sonido de que faltan balas y return, si no, aplicar toda la lógica de disparo

        //Llamar al cooldown, para que no puedas disparar 10 rpgs por segundo.

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);


        Vector3 direccion = targetPoint - Camera.main.transform.position;

        int i = 0;
        for (; i < _piscina.Balas.Length; i++)
        {
           
            if (!_piscina.Balas[i].activeInHierarchy)
            {
                _piscina.Balas[i].SetActive(true);
                break;
            }
        
        }
       

        _piscina.BalaScript(i).IniciarDisparo(this.dmg, transform, direccion);
       



    }

    private void Awake()
    {
        Iniciar();

    }
    void Start()
    {
        

    }

    
    void Update()
    {
        
    }
}
