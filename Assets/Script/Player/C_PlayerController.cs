using UnityEngine;


//Clase maneja entradas de movimiento del jugador
public class C_PlayerController : MonoBehaviour
{
    private enum EStatePlayer
    {
        ESP_Idle,
        ESP_Jump,
        ESP_Run,
        ESP_Attacking
    }
    private ELevel CurrentLevel => C_Managment.Instance.GetCurrentLevel();
    private Rigidbody2D rb;
    private Animator Animator;
    private float XInput; //Entradas valores en X
    private float Horizontal; //Entradas en X Vartiable Aux
    private int Side; //Mira el lado que esta mirando el jugador ( 1 = Der, -1 = Izq)
    private bool bWinner; //Comprueba si el jugador gano el nivel
    [SerializeField] private EStatePlayer StatePlayer;
    [SerializeField] GameObject FinalHeight; //Altura del final del nivel
    [SerializeField] float Speed; //Velocidad jugador
    [SerializeField] float JumpForce; //Fuerza de salto
    [SerializeField] Transform GroundTouched; //Suelo tocado
    [SerializeField] LayerMask WhatIsGround; //Donde se puede saltar
    

    /*
     * Getters y setters
     */
    public int GetPlayerSide() { return Side; }
    public void SetPlayersWinner(bool End) { bWinner =  End; }
   


    void Start()
    {
        StatePlayer = EStatePlayer.ESP_Idle;
        rb = GetComponent<Rigidbody2D>();
        Side = 1;
        bWinner = false;
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bWinner) return;
        Horizontal = Input.GetAxisRaw("Horizontal");
        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Jumping",!IsGrounded());
        FlipPlayer();
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            if (StatePlayer == EStatePlayer.ESP_Attacking) return;
            Jump();
        }
        ChangeStatePlayer();
    }

    public void FixedUpdate()
    {
        if (!bWinner)
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
        if (CurrentLevel == ELevel.EL_AverageLevel)
        {
            MovePlayerOut();
        }
        else if(CurrentLevel == ELevel.EL_BossLevel)
        {
            //PONER ANIMACION/COMPORTAMIENTO DE VICTORIA
        }
    }

    private void MovePlayerOut()
    {
        float i = 0.001f;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        transform.position = new Vector2(transform.position.x + i, FinalHeight.transform.position.y);
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
    
    private void ChangeStatePlayer()
    {
        switch(StatePlayer)
        {
            case EStatePlayer.ESP_Run:
                Animator.SetBool("Running", Horizontal != 0.0f);

                break;
        }
    }
}

