using UnityEngine;
using UnityEngine.InputSystem;

public class ProyectilFase2 : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject jugador;
    //controladorJugador vida;

    void Start()
    {
        //jugador = FindFirstObjectByType<controladorJugador>().gameObject;
       // vida = jugador.GetComponent<controladorJugador>();
        rb = GetComponent<Rigidbody2D>();     
        rb.linearVelocity = transform.right * 20;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            //vida.vidaJugador.fillAmount = Mathf.Clamp(vida.vidaJugador.fillAmount - 0.33f, 0f, 1f);
            Destroy(gameObject);

        }
        if (collision.gameObject.tag == "Piso")
        {
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
