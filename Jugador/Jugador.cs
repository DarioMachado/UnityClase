using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour, IDamageable
{

    public int vida;
    public float velocidad;
    public Arma[] armas;
    private Camera cam;
    public float sensibilidadCamara; //TODO: MENU PAUSA/OPCIONES Y AÑADIRLE GETTERS Y SETTERS A ESTO???
    private Rigidbody rb;
    private int armaActual;

    void Start()
    {
        armaActual = 0;
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        cam.transform.position = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    
    }

    public void RecibirDMG(int dmg)
    {
        vida -= dmg;

        if (vida < 0)
            Morir();
    }

    public void Saltar() { 
    
    }


    private float rotacionVertical;
    private void MoverCamara() {

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadCamara;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadCamara;

        rotacionVertical -= mouseY;
        rotacionVertical = Mathf.Clamp(rotacionVertical, -90, 90);

        transform.Rotate(0, mouseX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotacionVertical, 0, 0);
    }


    private void Morir() {
        //Respawn??? game over??? pérdida de dinero??? pérdida de exp??? 
        Debug.Log("Tienes menos de 0 vida!");
    }
    private void MoverJugador()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoAvance = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * movimientoAvance * Time.deltaTime * velocidad);
        transform.Translate(Vector3.right * movimientoHorizontal * Time.deltaTime * velocidad);
    }

    private void CambiarArma(int nuevaArma)
    {
        armas[armaActual].gameObject.SetActive(false);
        armaActual = nuevaArma;
        armas[armaActual].gameObject.SetActive(true);

    }

    public void MiscInputs() { 
    
    
    
    }

    void Update()
    {
        MoverCamara();
        MoverJugador();
        MiscInputs();

        if (Input.GetButtonDown("Fire1"))
        {
            armas[armaActual].Atacar();
        }

    }

    
}
