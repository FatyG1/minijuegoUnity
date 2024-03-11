using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo : MonoBehaviour
{
    //Variable para el sonido
    AudioSource deadSound;
    Rigidbody2D rb2d;
    //Variable de velocidad
    public int speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Recupero AudioSource
        deadSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //Movimiento en una zona controlada
        if(Mathf.Abs(transform.position.x) >3){
            speed = -speed;
        }
        //Modifico vector de velocidad
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }    
    private void OnCollisionEnter2D(Collision2D collision){
        //deadSound = GetComponent<AudioSource>();
        if(collision.transform.tag == "Player"){
            deadSound.Play();
                    }
    }
}
