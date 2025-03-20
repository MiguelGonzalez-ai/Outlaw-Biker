using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class controladorJugador : MonoBehaviour
{
    Rigidbody2D rb;
    public Image vidaJugador;
    public AudioClip sonidoColeccionable;
    Vector2 spawn;
    public int nivel;
    //Lanzamiento proyectiles Jefe final
    public GameObject proyectilJudador;
    public ProyectilJugador ladoJugador;
    public Transform posicionLanzamiento;
    public int proyectiles = 0;
    public int lado = 1;
    public float dañoProyectil;
    public float velocidadX;
    public float velocidadY;
    //----------------------------------
    public bool ganador = false;
    public float alturaFinal = 0;
    float xInput;
    float zInput;
    

    [SerializeField] private float speed = 10;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private Transform sueloTocado;
    [SerializeField] private LayerMask queEsSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawn = (Vector2)transform.position;
    }

    void Update()
    {
        voltearJugador();
        if (vidaJugador.fillAmount < 0.05f) //Si la vida del jugador llega a cero, se muere
        {
            if(nivel == 1) //Nivel promedio
            {
                transform.position = spawn;
                vidaJugador.fillAmount = 1;
            }else if(nivel == 2) //Jefe final
            {
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * (jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }

        if (proyectiles > 0 && Input.GetKeyDown(KeyCode.R))
        {
            lanzadorProyectiles();
        }

    }

    private void FixedUpdate()
    {
        if (!ganador)
        {
            HandleMovement();
        }
        else
        {
            moviemientoGanador();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Destroy(collision.gameObject);
            
        }
        
        if (collision.gameObject.tag == "Coleccionable")
        {
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().PlayOneShot(sonidoColeccionable); //NOS PERMITE ELEGIR EL AUDIO
        }
    }



    private void HandleMovement()
    {
        xInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(xInput * speed, rb.linearVelocity.y);
        rb.linearVelocity = move;

    }

    private void voltearJugador()
    {
        if(xInput > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1,1,1);
            lado = 1;
        }else if(xInput < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            lado = -1;
        }
    }

    private void moviemientoGanador()
    {
        float i = 0.001f;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        transform.position = new Vector2(transform.position.x + i, alturaFinal);
        //SceneManager.LoadScene("Level2");
    }

    private void lanzadorProyectiles()
    {
        
        ladoJugador.lado = lado;
        ladoJugador.vx = velocidadX;
        ladoJugador.vy = velocidadY;
        ladoJugador.daño = dañoProyectil;
        Instantiate(proyectilJudador, posicionLanzamiento.position , Quaternion.identity);
        proyectiles--;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(sueloTocado.position, sueloTocado.localScale.x, queEsSuelo);
    }
}
