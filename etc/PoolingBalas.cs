using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Se crea un objeto vacío y se añade al jugador (el nombre no importa, aunque debería de ser algo como Balas) A ese objeto vacío se le añade este script.
 */
public class PoolingBalas : MonoBehaviour
{
    public GameObject balaPrefab;
    private GameObject[] balas;
    private Bala balaScript;
    private void Awake()
    {
        

        balas = new GameObject[50]; //Por ejemplo
        for (int i = 0; i < balas.Length; i++)
        {
            balas[i] = Instantiate(balaPrefab, transform);
            balas[i].SetActive(false);
        }
    }


    public GameObject[] Balas {
        get { return balas; }
        set { balas = value; }
    }

    public Bala BalaScript(int index)
    {  
        return balas[index].GetComponent<Bala>();
    }


}
