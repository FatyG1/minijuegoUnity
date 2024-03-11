using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollision : MonoBehaviour
{   
    public GameObject Menu;
    public GameObject GameOver;

    public GameObject Winner;
    public GameObject Jugador;
        private void OnCollisionEnter2D(Collision2D collision){
        //deadSound = GetComponent<AudioSource>();
        if(collision.transform.tag == "Enemy"){
            Debug.Log("Game Over");
            Menu.SetActive(true);
            GameOver.SetActive(true);
            Jugador.SetActive(false);
                    }
        if(collision.transform.tag == "Finish"){
            Winner.SetActive(true);
            Debug.Log("Has ganado");
            Menu.SetActive(true);            
            Jugador.SetActive(false);
        }    
    }
    
    
}
