using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoJugador : MonoBehaviour
{
    //Variable para el mapa de acción 
    ControlesUsuario controls; 

    //Variable para la direccion
    public float direction =0;

    //Variable velocidad
    public float speed = 400;

    public Rigidbody2D playerRB;

    //Referencia Animator
    public Animator animator; 

    //Variable para controlar hacia donde mira el jugador
    bool isFacingRight = true;

    //Variable para la fuerza del salto
    public float jumpForce = 5;
    //Variable para el sonido
    AudioSource jumpSound;
    //Variable para comprobar si esta en el suelo
    bool isGrounded;
    int numberOfJumps;

    //Variable para groundcheck;
    public Transform GroundCheck;
    //Variable para el suelo
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Awake()
    {
        //Inicializo los controles
        controls = new ControlesUsuario();
        controls.Enable();

        //Compruebo las vinculaciones del mapa de acción
        controls.Land.Move.performed += ctx => {
            //Aciones que se ejecutan cuando se activa Move
            direction = ctx.ReadValue<float>();
        };    
        //Aciones que se ejecutan cuando se activa jump
        controls.Land.Jump.performed += ctx => Jump();

        //Recupero AudioSource
        jumpSound = GetComponent<AudioSource>();
     }

    // Se llama un numero constante de veces por segundo
    void FixedUpdate()
    {
        //Compruebo si el jugador esta en el suelo
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.1f, groundLayer);

        //Paso el valor obtenido en el controlador de animacion
        animator.SetBool("isGrounded", isGrounded);

        //Muevo el jugador
        playerRB.velocity = new Vector2(direction*speed*Time.fixedDeltaTime, playerRB.velocity.y);

        //Uso Animator para cambiar speed
        animator.SetFloat("Speed", Mathf.Abs(direction));

        //Comprueba la direccion del personaje y la modifica
        if(isFacingRight && direction <0 || !isFacingRight && direction >0 ){
            Flip();
        }
    }
    //Metodo que da la vuelta al jugador
    void Flip(){
        isFacingRight = !isFacingRight;

        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
    //Metodo para controlar el salto
    void Jump(){
        if(isGrounded){
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            jumpSound.Play();
        }
        else{
            if(numberOfJumps == 1){
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                jumpSound.Play();
            }
        }
    }
}
