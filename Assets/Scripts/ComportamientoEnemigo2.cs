using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo2 : MonoBehaviour
{
    //Variable para el sonido
    AudioSource deadSound;
     Rigidbody2D rb2d;
    //Variable de velocidad
    public float speed = 0.8f;
    //Variable de rango
    public float range = 3;
    //Variable de posicion inicial Y
    float startingY;
    //Direccion
    int dir =1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
        //Recupero AudioSource
        deadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        
        //Movimiento de arriba abajo
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime * dir);
        //Comprueba si llega al limite. 
        if(transform.position.y < startingY || transform.position.y > startingY + range){
            dir *= -1;
        } 
    } 
     private void OnCollisionEnter2D(Collision2D collision){
        //deadSound = GetComponent<AudioSource>();
        if(collision.transform.tag == "Player"){
            deadSound.Play();
            }
    }
}
