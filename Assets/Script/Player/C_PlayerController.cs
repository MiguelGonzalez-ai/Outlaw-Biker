using UnityEngine;

//Clase maneja entradas de movimiento del jugador 2
//Prueba Git
public class C_PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float XInput;
    float YInput;
    [SerializeField] GameObject FinalHeight; //Altura del final del nivel
    [SerializeField] float Speed; //Velocidad jugador
    [SerializeField] float JumpForce; //Fuerza de salto
    [SerializeField] Transform GroundTouched; //Suelo tocado
    [SerializeField] LayerMask WhatIsGround; //Donde se puede saltar
    public int Side; //Mira el lado que esta mirando el jugador ( 1 = Der, -1 = Izq)
    public bool Winner; //Comprueba si el jugador gano el nivel

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Side = 1;
        Winner = false;
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
    }

    public void FixedUpdate()
    {
        if (!Winner)
        {
            HandleMovement();
        }
        else
        {
            WinnerMovement();
        }
    }

    /*
     * Maneja las entradas del movimiento del jugador de forma 2D
     */
    private void HandleMovement()
    {
        XInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(XInput * Speed * Time.deltaTime, rb.linearVelocity.y);
        rb.linearVelocity = move;

    }

    /*
     * Realiza que el jugador salte solo si se oprime el boton espacio
     */
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * (JumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
    }

    /*
     * Voltea al jugador dependiendo hacia que direccion se mueve
     */
    private void FlipPlayer()
    {
        if (XInput > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            Side = 1;
        }
        else if (XInput < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            Side = -1;
        }
    }

    /*
     * Si el jugador llega a la meta del nivel, restringe el movimiento y lo
     * desplaza hacia la derecha
     */
    private void WinnerMovement()
    {
        float i = 0.001f;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        transform.position = new Vector2(transform.position.x + i, FinalHeight.transform.position.y);
        //SceneManager.LoadScene("Level2");
    }

    /*
     * Verifica si el jugador esta tocando el suelo
     */
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundTouched.position, GroundTouched.localScale.x, WhatIsGround);
    }

    public void Bounce(float SpeedBounce)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 10);
    }    
}

