using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instancia para controlar el SoundManager
        public static SoundManager instance;
    //Atributo para AudioSource
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido. 
    public void PlaySound(){
        source.Play();
    }

}
