using System.Collections;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject jugador;
    controladorJugador vida;
    public float fuerzaBala;
    public int aux = -1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jugador =  FindFirstObjectByType<controladorJugador>().gameObject;
        vida = jugador.GetComponent<controladorJugador>();

        Vector2 velocity = new Vector2(aux * fuerzaBala, 0);
        rb.linearVelocity = velocity;
        StartCoroutine(DestruirBalas(3));

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (aux == 1)
        {
            transform.Rotate(Vector3.forward, 10);
        }
        else if (aux == 2)
        {
            transform.Rotate(-Vector3.forward, 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jugador")
        {
            vida.vidaJugador.fillAmount = Mathf.Clamp(vida.vidaJugador.fillAmount - 0.2f, 0f, 1f);
            Destroy(gameObject);

        }
    }

    IEnumerator DestruirBalas(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
