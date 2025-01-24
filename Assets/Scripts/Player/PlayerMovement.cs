using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    //Si usamos el GetButton es para saber si esta siendo presionado
    [Header("CharacterController")]
    public CharacterController characterController;

    [Header("Gravedad/Velocidad/Salto jugador")]
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;


    [Header("Para detectar el suelo")]
    //Referencia al choque con el suelo
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    //Recomendame hacer un layer para detectar el suelo
    public LayerMask groundMask;

    bool isGrounded;
   
    Vector3 velocity;

    [Header("Cámara del jugador")]
    public Camera playerCamera; // Asigna la cámara desde el Inspector
    void Start()
    {
        // Desactivamos la cámara si este objeto no pertenece al jugador local
        if (!GetComponent<PhotonView>().IsMine && playerCamera != null)
        {
            playerCamera.enabled = false; // Desactiva la cámara del jugador remoto
        }
    }
    void FixedUpdate()
    {
        if (GetComponent<PhotonView>().IsMine==true)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                //Si se coloca en 0 puede dar error
                velocity.y = -2f;
            }

            //Variables de movimiento de lado a lado
            float x = Input.GetAxis("Horizontal");
            //De arriba a abajo
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            // Movimiento del personaje
            characterController.Move(move * speed * Time.deltaTime);
            //Para el salto 
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                //Velocidad en el eje vertical
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }


            // Aplicamos gravedad
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
